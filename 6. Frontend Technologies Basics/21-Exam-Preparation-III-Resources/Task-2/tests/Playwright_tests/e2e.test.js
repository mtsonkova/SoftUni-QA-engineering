const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

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
        test('Register user makes the correct API call and registers user successfully', async() => {
            //arange
            let random = Math.floor(Math.random() * 10000);
            let email = `email${random}@abv.bg`;
            user.email = email;

            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#repeat-pass').fill(user.confirmPass);

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

        test('Login user with valid credentials makes the correct API call and logs in user successfully', async() => {
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

        test('Log out makes the correct API call and logs out user successfully', async() => {
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
            await expect(page.url()).toBe(host + '/' || host + '/logout');
            let logInBtn = page.locator('text=Login');
            await expect(logInBtn).toBeVisible();
        });
    })

    describe("navbar", () => {
        test('Check the Navbar for Logged-In user', async() => {
            //arange
            await page.goto(host);
            
            //act
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            //assert
            expect(await page.locator('navbar >> text=Dashboard').toBeVisible);
            expect(await page.locator('text=My Books').toBeVisible);
            expect(await page.locator('text=Add Book').toBeVisible);
            expect(await page.locator('text=Logout').toBeVisible);
            expect(await page.locator('text=Login').toBeHidden);
            expect(await page.locator('text=Register').toBeHidden);
        });

        test('Check the Navbar for guest user', async() => {
           //act
            await page.goto(host);
            
            //assert
            expect(await page.locator('text=Dashboard').toBeVisible);
            expect(await page.locator('text=My Books').toBeHidden);
            expect(await page.locator('text=Add Book').toBeHidden);
            expect(await page.locator('text=Logout').toBeHidden);
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
       
        test('Create book call the correct API and book is added successfully', async() => {
           //arrange
        
           await page.click('text=Add Book');
           await page.waitForSelector('form');

            //act
            await page.fill('[name="title"]', "Random title");
            await page.fill('[name="description"]', "Random description");
            await page.fill('[name="imageUrl"]', "https://jpeg.org/images/jpeg-home.jpg");
            await page.locator('#type').selectOption('Other');
            
            let [addBookResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/data/books') && response.status() === 200),
                page.click('[type="submit"]')
            ]);

            await expect(addBookResponse.ok()).toBeTruthy();

            let bookData = await addBookResponse.json();

            await expect(bookData.title).toEqual('Random title');
            await expect(bookData.description).toEqual('Random description');
            await expect(bookData.imageUrl).toEqual('https://jpeg.org/images/jpeg-home.jpg');

            await expect(bookData.type).toEqual('Other');
        });

        test('Edit book calls the correct API and a book is edited successfully', async() => {
            //arange
            await page.click('text=My Books');
            await page.locator(`text=Details`).first().click();
            await page.click('text=Edit');
            await page.waitForSelector('form');

            //act
            await page.fill('[name="title"]', "Edit Random title");
            await page.fill('[name="description"]', "Edit Random description");
            await page.fill('[name="imageUrl"]', "https://jpeg.org/images/jpeg-home3.jpg");
            await page.locator('#type').selectOption('Fiction');
            
            let [editBookResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/data/books') && response.status() === 200),
                page.click('text=Edit')
            ]);

            await expect(editBookResponse.ok()).toBeTruthy();

            let bookData = await editBookResponse.json();

            await expect(bookData.title).toEqual('Edit Random title');
            await expect(bookData.description).toEqual('Edit Random description');
            await expect(bookData.imageUrl).toEqual('https://jpeg.org/images/jpeg-home3.jpg');

            await expect(bookData.type).toEqual('Fiction');

        });

        test('Delete book makes the correct API call and a book is deleted successfully', async() => {
            await page.click('text=My Books');
            await page.locator(`text=Details`).first().click();

            let [deleteBookResponse] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/data/books') && response.status() === 200),
                page.click('text=Delete')
            ]);

            expect(deleteBookResponse.ok()).toBeTruthy();
        });
    })
})