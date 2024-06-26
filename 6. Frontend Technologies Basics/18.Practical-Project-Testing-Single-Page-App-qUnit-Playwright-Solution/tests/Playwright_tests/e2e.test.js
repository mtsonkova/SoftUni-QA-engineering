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

let game = {
    title: '',
    category: '',
    maxLevel: '',
    imageUrl: '',
    summary: ''
}

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
        await context.close();
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

    describe('CRUD operations', () => {
        beforeEach(async() => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 10000);
            user.email = `abv_${random}@abv.bg`;
            await page.locator('#email').fill(user.email);
            await page.locator('#login-password').fill(user.password);
        
            await page.click('[type="submit"]');
        });


        test('Edit and delete buttons are not visible on Non-Owner gamae', async() => {
            await page.click('text=All Games');
          let elementDetails = await page.locator('.details-button').first();

          //act
          await elementDetails.click();
      
          //assert

            expect(page.locator('text=Edit')).toBeHidden;
            expect(page.locator('text=Delete')).toBeHidden;
        });

        test('create new game with valid data', async() => {
            //arange

            game.title = 'Halo Universe';
            game.category = 'Action and 3D person shooter';
            game.maxLevel = '100';
            game.imageUrl = 'halo/masterchief.png'
            game.summary = 'Cool game for all fans of 3D shooting.';
           
            await page.click('text=Create Game');
            await page.locator('#title').fill(`${game.title}`);
            await page.locator('#category').fill(`${game.category}`);
            await page.locator('#maxLevel').fill(`${game.maxLevel}`);
            await page.locator('#imageUrl').fill(`${game.image}`);
            await page.locator('#summary').fill(`${game.summary}`);

            //act
            let [response] = await Promise.all([response => response.url().includes('/data/games') && response.status() === 200,
                page.click('[type="submit"]')                
            ]);
            
            //assert
            expect(response.ok).toBeTruthy();

            let json = await response.json();

            expect(json.title).toEqual(game.title);
            expect(json.category).toEqual(game.category);
            expect(json.maxLevel).toEqual(game.maxLevel);
            expect(json.imageUrl).toEqual(game.imageUrl);
            expect(json.summary).toEqual(game.summary);

        });

        test('create game with empty fields should not work', async() => {
            //arange
            await page.click('text=Create Game');

            //act
            page.click('[type="submit"]');

            //assert
            expect(page.url()).toEqual(host + '/data/games');
        });
    });
});