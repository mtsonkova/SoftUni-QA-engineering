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

let homeUrl = host + '/';


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
        test('Register with valid data', async () => {
            //arange
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 10000);
            user.email = `email${random}@abv.bg`;

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#repeat-pass').fill(user.confirmPass);

            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/register') && response.status() == 200),
                page.click('[type="submit"]')
            ]);

            //assert
            await expect(response.ok()).toBeTruthy();

            let userData = await response.json();

            await expect(userData.email).toBe(user.email);
            await expect(userData.password).toBe(user.password);
        });

        test('Login with valid data', async () => {
            // arange
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);

            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/login') && response.status() == 200),
                page.click('[type="submit"]')
            ]);

            //assert
            await expect(response.ok()).toBeTruthy();

            let userData = await response.json();

            await expect(userData.email).toBe(user.email);
            await expect(userData.password).toBe(user.password);

        });

        test('Logout from the application', async () => {
            //arrange

            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            //act
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/logout') && response.status() == 204),
                page.click('text=Logout')
            ]);

            //assert
            await expect(response.ok()).toBeTruthy();
            await page.waitForSelector('text=Login');
            await expect(page.url()).toBe(homeUrl);

        });

    })

    describe("navbar", () => {
        test('Test the navbar for guest user', async () => {
            //arrange
            await page.goto(host);

            //assert
            await expect(page.locator('nav >> text=Dashboard')).toBeVisible;
            await expect(page.locator('nav >> text=My Books')).toBeHidden;
            await expect(page.locator('nav >> text=Add Book')).toBeHidden;
            await expect(page.locator('nav >> text=Logout')).toBeHidden;
            await expect(page.locator('nav >> text=Login')).toBeVisible;
            await expect(page.locator('nav >> text=Register')).toBeVisible;
        });

    });

    test('Test navbar for Logged-in user', async () => {
        //arrange
        await page.goto(host);

        //act
        await page.click('text=Login');
        await page.waitForSelector('form');
        await page.locator('#email').fill(user.email);
        await page.locator('#password').fill(user.password);
        await page.click('[type="submit"]');

        //assert
        await expect(page.locator('nav >> text=Dashboard')).toBeVisible;
        await expect(page.locator('nav >> text=My Books')).toBeVisible;
        await expect(page.locator('nav >> text=Add Book')).toBeVisible;
        await expect(page.locator('nav >> text=Logout')).toBeVisible;
        await expect(page.locator('nav >> text=Login')).toBeHidden;
        await expect(page.locator('nav >> text=Register')).toBeHidden;
    });
});

describe("CRUD", () => {
    beforeEach(async () => {

        await page.goto(host);

        await page.click('text=Login');
        await page.waitForSelector('form');
        await page.locator('#email').fill(user.email);
        await page.locator('#password').fill(user.password);
        await page.click('[type="submit"]');
    });

    test('Test Create a book functionality', async () => {
        //arrange
        await page.click('text=Add Book');
        await page.waitForSelector('form');

        //act

        await page.locator('#title').fill('Random Title');
        await page.locator('#description').fill('Random description');
        await page.locator('#imageUrl').fill('image.jpg');
        await page.locator('#type').selectOption('Other');

        //act
        let [response] = await Promise.all([
            page.waitForResponse(response => response.url().includes('/data/books') && response.status() == 200),
            page.click('[type="Submit"]')
        ]);

        let bookData = await response.json();

        //assert
        await expect(response.ok()).toBeTruthy();
        await expect(bookData.title).toBe('Random Title');
        await expect(bookData.description).toBe('Random description');
        await expect(bookData.imageUrl).toBe('image.jpg');
        await expect(bookData.type).toBe('Other');
    });

    test('Edit a book functionality', async () => {
        //arrange
        await page.click('text=My Books');
        await page.locator('text=Details').first().click();
        await page.click('text=Edit');
        await page.waitForSelector('form');

        //act
        await page.locator('#title').fill('Edited Random Title');
        await page.locator('#description').fill('Edited Random description');
        await page.locator('#type').selectOption('Other');
        let [response] = await Promise.all([
            page.waitForResponse(response => response.url().includes('/data/books') && response.status() == 200),
            page.click('[type="Submit"]')
        ]);

        let bookData = await response.json();

        //assert
        await expect(response.ok()).toBeTruthy();
        await expect(bookData.title).toBe('Edited Random Title');
        await expect(bookData.description).toBe('Edited Random description');
        await expect(bookData.imageUrl).toBe('image.jpg');
        await expect(bookData.type).toBe('Other');
    })

    test('Delete a book functionality', async () => {
        await page.click('text=My Books');
        await page.locator('text=Details').first().click();
        await page.click('text=Delete');

        let [response] = await Promise.all([
            page.waitForResponse(response => response.url().includes('/data/books') && response.status() == 200),
            page.click('text=Delete')
        ]);

        await expect(response.ok()).toBeTruthy();

    })

});


//https://pastebin.com/zt9uYPup