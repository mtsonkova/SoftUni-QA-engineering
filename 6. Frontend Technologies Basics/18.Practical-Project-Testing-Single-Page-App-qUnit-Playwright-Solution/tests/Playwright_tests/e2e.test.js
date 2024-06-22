const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email: '',
    password: '123456',
    confimrPass: '123456'
};


describe('gamesApp e2e tests', () => {
    // use beforeAll and afterAll
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
        await context.close()
    });

    describe('authentication', () => {
        test('register with valid data', async () => {
            //Arrange
            await page.goto(host);
            await page.click('text=Register');

            await page.waitForSelector('form');


            let random = Math.floor(Math.random() * 10000);
            user.email = `abv_${random}@abv.bg`;

            //Act
            await page.locator('#email').fill(user.email);
            await page.locator('#register-password').fill(user.password);
            await page.locator('#confirm-password').fill(user.confimrPass);

            let [response] = await Promise.all([ // create promise all to wait for the redirection after the btn is clicked
                page.waitForResponse(response => response.url().includes('/users/register') && response.status() === 200),
                page.click('[type="submit"]')
            ]);

            // Assert
            await expect(response.ok()).toBeTruthy();
            let userData = await response.json();

            expect(userData.email).toBe(user.email);
            expect(userData.password).toEqual(user.password);
        });

        test('register with empty fields should not work', async() => {
            //arrange
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');
                       
            //act
            await page.click('[type="submit"]');
            
            //assert
            expect(page.url()).toBe(host + '/register');
        });

        test('Login with valid user credentials', async() => {
            //arrange
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            
            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#login-password').fill(user.password);
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/login') && response.status() === 200),
                page.click('[type="submit"]')
            ]);
            
            //assert
            expect(response.ok()).toBeTruthy();

            let userData = await response.json();
            
            expect(userData.email).toBe(user.email);
            expect(userData.password).toEqual(user.password);
        });

        test('Login with enpty fields should not work', async() => {
            //arrange
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            // act
            await page.click('[type="submit"]');
            
            // assert
            expect(page.url()).toBe(host + '/login');
        });

        test('Logout from the application', async() => {
            //arrange

            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            
            await page.locator('#email').fill(user.email);
            await page.locator('#login-password').fill(user.password);
            page.click('[type="submit"]')
           ;

            //act
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/logout') && response.status() === 204),
                page.locator('nav >> text=Logout').click()
            ]);

            //assert
            expect(response.ok()).toBeTruthy();
            await page.waitForSelector('nav >> text=Login');
            expect(page.url()).toBe(host + '/');

        }) 
    });

    describe('navigation bar tests', () => {
        test('navbar for guest user', async() => {
            //arrange
            await page.goto(host);

            //act && assert
            await expect(page.locator('text=All games')).toBeVisible;
            await expect(page.locator('text=Login')).toBeVisible;
            await expect(page.locator('text=Register')).toBeVisible;
            await expect(page.locator('text=Create Game')).toBeHidden;
            await expect(page.locator('text=Logout')).toBeHidden;
        });

        test('navbar for logged user', async() => {
            //arrange
            await page.goto(host);
            page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#login-password').fill(user.password);

            await page.click('[type="submit"]');

            //act and assert
            await expect(page.locator('text=All games')).toBeVisible;
            await expect(page.locator('text=Create Game')).toBeVisible;
            await expect(page.locator('text=Logout')).toBeVisible;
            await expect(page.locator('text=Login')).toBeHidden;
            await expect(page.locator('text=Register')).toBeHidden;

            //
        })
    });
});