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

let book = {
    title : 'The shadow of Xel Naga',
    description: 'In a distant desolated planet of Baker Ro an artifact with immence power is discovered.',
    imageUrl : 'protos/img.jpeg',
    type : 'other'

}

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
        test('Register with valid data', async() => {

            user.email = 'randomtestusermail@test.qa';

            //arrange
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');
            
            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#repeat-pass').fill(user.confirmPass);

            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/register') && response.status() === 200),
                page.click('[type="submit"]')
            ]);

            //assert
           await expect(response.ok()).toBeTruthy();

           let json = await response.json();

           await expect(json.email).toBe(user.email);
           await expect(json.password).toEqual(user.password);
        });

        test('Login with valid data', async() => {
            //arrange
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/login') && response.status() === 200),
                page.click('[type="submit"]')
            ]);

            //assert
            await expect(response.ok()).toBeTruthy();

           let json = await response.json();

           await expect(json.email).toBe(user.email);
           await expect(json.password).toEqual(user.password);

        });

        test('Logout from the application', async() => {
            //arrange
            await page.goto(host);
            let url = page.url();
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            let [logInResponse]  = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/login') && response.status() === 200),
                page.click('[type="submit"]')
            ]);
           
            //act
            let [response]  = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/logout') && response.status() === 204),
                page.click('[type="submit"]')
            ]);

            await expect(response.ok()).toBeTruthy();

            let json = await response.json();
            await expect(page.locator('text=Login')).toBeVisible;
            await expect(url).toEqual(host);
        });
        
    })

    describe("navbar", () => {
        test('Test the navbar for guest user', async() => {
            //arange
           
            let login = page.locator('text=Login');
            let register = page.locator('text=Register');
            let dashboard = page.locator('text=Dashboard').first();
            let myBooks = page.locator('text=My Books');
            let addBook = page.locator('text=Add Book');
            let logout = page.locator('text=Logout');

            //act
            await page.goto(host);

            // assert
            await expect(dashboard).toBeVisible;
            await expect(login).toBeVisible;
            await expect(register).toBeVisible;
            await expect(myBooks).toBeHidden;
            await expect(addBook).toBeHidden;
            await expect(logout).toBeHidden;            
        
        });             

        test('Test navbar for Logged-in user', async() => {
            //arrange

            let login = page.locator('text=Login');
            let register = page.locator('text=Register');
            let dashboard = page.locator('text=Dashboard').first();
            let myBooks = page.locator('text=My Books');
            let addBook = page.locator('text=Add Book');
            let logout = page.locator('text=Logout');


            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
          

            //act
            await page.click('[type="submit"]');

            //assert
            await expect(dashboard).toBeVisible;
            await expect(login).toBeHidden;
            await expect(register).toBeHidden;
            await expect(myBooks).toBeVisible;
            await expect(addBook).toBeVisible;
            await expect(logout).toBeVisible;      
        });
    });

    describe("CRUD", () => {
        beforeEach(async() => {
            await page.goto(host)
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            let [logInResponse]  = await Promise.all([
                page.waitForResponse(response => response.url().includes('/users/login') && response.status() === 200),
                page.click('[type="submit"]')
            ]);
        });

        test('Test Create a book functionality', async() => {
            await page.click(text='Add Book');
            await page.waitForSelector('form');
            await page.locator('#title').fill(book.title);
            await page.locator('#description').fill(book.description);
            await page.locator('#imageUrl').fill(book.imageUrl);

            const select = page.locator('#type');
            await select.selectOption({value :book.type});

             //act
             let [createBookResponse]  = await Promise.all([
                page.waitForResponse(response => response.url().includes('"/data/books') && response.status() === 200),
                page.click('[type="submit"]')
             ]);

             await expect(createBookResponse.ok()).toBeTruthy();

             let json = await createBookResponse.json();
             expect(json.title).toEqual(book.title);
             expect(json.description).toEqual(book.description);
             expext(json.imageUrl).toEqual(book.imageUrl);
             expect(json.type).toEqual(book.type);
        });

        test('Edit a book functionality', async() => {
            
        })
        
    })
})