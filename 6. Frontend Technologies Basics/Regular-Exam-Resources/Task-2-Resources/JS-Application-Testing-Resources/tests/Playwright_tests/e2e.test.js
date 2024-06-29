const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let albumName = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });


    describe("authentication", () => {
        test('Register user calls the correct API and registration is successfull', async () => {
            //arange
            let random = Math.floor(Math.random() * 10000);
            user.email = `user${random}@abv.bg`;
            console.log(user.email);
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#conf-pass').fill(user.confirmPass);

            let [registerResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/register') && response.status() == 200),
                page.click('[type="submit"]')
            ]);

            //assert
            await expect(registerResponse.ok()).toBeTruthy();
            let userData = await registerResponse.json();

            await expect(userData.email).toBe(user.email);
            await expect(userData.password).toBe(user.password);

        });

        test('Login user with valid credentials makes the correct API call and logs in user successfully', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);

            let [loginResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/login') && response.status() == 200),
                page.click('[type="submit"]')
            ]);

            //assert
            await expect(loginResponse.ok()).toBeTruthy();
            let userData = await loginResponse.json();

            await expect(userData.email).toBe(user.email);
            await expect(userData.password).toBe(user.password);

        });

        test('Log out makes the correct API call and logs out user successfully', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            let [logoutResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/logout') && response.status() == 204),
                page.click('text=Logout')
            ]);

            await expect(logoutResponse.ok()).toBeTruthy();
            await expect(page.url()).toContain(host + '/');
            let logInBtn = page.locator('text=Login');
            await expect(logInBtn).toBeVisible();
        });
    });

    describe("navbar", () => {
        test('Check the Navbar for Logged-In user', async () => {
            //arange
            await page.goto(host);

            //act
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            //assert
            expect(await page.locator('navbar >> text=Home').toBeVisible);
            expect(await page.locator('text=Catalog').toBeVisible);
            expect(await page.locator('text=Search').toBeVisible);
            expect(await page.locator('text=Create Album').toBeVisible);
            expect(await page.locator('text=Logout').toBeVisible);
            expect(await page.locator('text=Login').toBeHidden);
            expect(await page.locator('text=Register').toBeHidden);
        });

        test('Check the Navbar for guest user', async () => {
            //act
            await page.goto(host);

            //assert
            expect(await page.locator('navbar >> text=Home').toBeVisible);
            expect(await page.locator('text=Catalog').toBeVisible);
            expect(await page.locator('text=Search').toBeVisible);
            expect(await page.locator('text=Create Album').toBeHiden);
            expect(await page.locator('text=Logout').toBeHiden);
            expect(await page.locator('text=Login').toBeVisible);
            expect(await page.locator('text=Register').toBeVisible);
        });

    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator("#email").fill(user.email);
            await page.locator("#password").fill(user.password);
            await page.click('[type="submit"]');
        });

        test('Create album call the correct API and the album is added successfully', async () => {
            //arrange

            let random = Math.floor(Math.random() * 10000);
            albumName = `Random Album ${random}`;

            await page.click('text=Create Album');
            await page.waitForSelector('form');

            //act
            await page.fill('[name="name"]', albumName);
            //imageUrl, price, Release date, Artist, Genre, Description
          
            await page.fill('[name="imgUrl"]', "/images/pinkFloyd.jpg");

            await page.fill('[name="price"]', "$12.00");
            await page.fill('[name="releaseDate"]', "141225");
            await page.fill('[name="artist"]', "Random Artist");
            await page.fill('[name="genre"]', "Random Genre");
            await page.fill('[name="description"]', "Random album description");

            let [createAlbumResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/data/albums') && response.status() === 200),
                page.click('[type="submit"]')
            ]);

            await expect(createAlbumResponse.ok()).toBeTruthy();

            let albumData = await createAlbumResponse.json();

            await expect(albumData.name).toEqual(albumName);
            await expect(albumData.imgUrl).toEqual('/images/pinkFloyd.jpg');
            await expect(albumData.price).toEqual("$12.00");
            await expect(albumData.releaseDate).toEqual("141225");
            await expect(albumData.artist).toEqual('Random Artist');
            await expect(albumData.genre).toEqual('Random Genre');
            await expect(albumData.description).toEqual('Random album description');
           
        });

        test('Edit album calls the correct API and the album is edited successfully', async () => {
            //arange
            await page.click('text=Search');
            await page.fill('[name="search"]', albumName);
            await page.click('.button-list');
            await page.locator(`text=Details`).first().click();
            await page.click('text=Edit');
            await page.waitForSelector('form');

            //act
          
            await page.fill('[name="description"]', "This album has all my favorite songs");
            await page.fill('[name="price"]', "$6.00");
            

            let [editAlbumResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/data/albums') && response.status() === 200),
                page.click('[type="submit"]')
            ]);

            await expect(editAlbumResponse.ok()).toBeTruthy();

            let albumData = await editAlbumResponse.json();

            await expect(albumData.name).toEqual(albumName);
            await expect(albumData.imgUrl).toEqual('/images/pinkFloyd.jpg');
            await expect(albumData.price).toEqual("$6.00");
            await expect(albumData.releaseDate).toEqual("141225");
            await expect(albumData.artist).toEqual('Random Artist');
            await expect(albumData.genre).toEqual('Random Genre');
            await expect(albumData.description).toEqual('This album has all my favorite songs');
        });

        test('Delete album makes the correct API call and the album is deleted successfully', async () => {
            await page.click('text=Search');
            await page.fill('[name="search"]', albumName);
            await page.click('.button-list');
            await page.locator(`text=Details`).first().click();
                     
            let [deleteAlbumResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/data/albums') && response.status() == 200),
                page.click('.actionBtn >> a')               
            ]);

            expect(deleteAlbumResponse.ok()).toBeTruthy();
        });
    });
});