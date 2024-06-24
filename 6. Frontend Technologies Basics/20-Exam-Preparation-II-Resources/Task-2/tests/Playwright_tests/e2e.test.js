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
        test('Registration with valid data', async() => {
            let email = 'qatest@mail.com';
            user.email = email;
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');
            await page.locator('#email').fill(email);
            await page.locator('#password').fill(user.password);
            await page.locator('#repeatPassword').fill(user.confirmPass);

            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/register') && response.status() === 200),
                page.click('[type = "submit"]')
            ]);

            await expect(response.ok()).toBeTruthy();
            
            let userData = await response.json();
            await expect(userData.email).toBe(user.email);
            await expect(userData.password).toBe(user.password);
        })
        
    });

    describe("navbar", () => {
        
    });

    describe("CRUD", () => {
        
    })
})