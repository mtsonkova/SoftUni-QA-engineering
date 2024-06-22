const baseUrl = 'http://localhost:3030/';
let user = {
    email: "",
    password: '123456'
};

let token = '';
let userId = '';

let game = {
    title: '',
    category: '',
    maxLevel: '71',
    imageUrl: './images/ZombieLang.png',
    summary: ''
}

let lastCreatedGameId = '';

QUnit.config.reorder = false;

QUnit.module('user functionalities', () => {
    QUnit.test('registration', async (assert) => {
        let path = 'users/register';

        let random = Math.floor(Math.random() * 10000);
        let email = `abv${random}@abv.bg`;

        user.email = email;

        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },


            body: JSON.stringify(user)
        });

        let json = await response.json();


        assert.ok(response.ok, 'successfull response');
        //assert email
        assert.ok(json.hasOwnProperty('email'), 'email exist');
        assert.equal(json['email'], user.email, 'expexted mail');
        assert.strictEqual(typeof json.email, 'string', 'Property email is a string');

        //assert password
        assert.ok(json.hasOwnProperty('password'), 'Password exists.');
        assert.equal(json['password'], user.password, 'expected password')
        assert.strictEqual(typeof json.password, 'string', 'Property password is a string.');

        //access token
        assert.ok(json.hasOwnProperty('accessToken'), 'access token exists');
        let accessToken = json['accessToken'] // get token;
        assert.strictEqual(typeof json['accessToken'], 'string', 'Property accessToken is string.');

        //id
        assert.ok(json.hasOwnProperty('_id'), 'id exists');
        let id = json['_id']; //get user id
        assert.strictEqual(typeof json['_id'], 'string', 'Property _id is a string');

        token = json['accessToken']; // get token;
        userId = json['_id']; // get userId
        sessionStorage.setItem('game-user', JSON.stringify(user)); //set token to session store in browser
    });

    QUnit.test('login', async (assert) => {
        let path = 'users/login';
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        let json = await response.json();
        assert.ok(response.ok, 'successfull response');

        //assert email
        assert.ok(json.hasOwnProperty('email'), 'email exist');
        assert.equal(json['email'], user.email, 'expexted mail');
        assert.strictEqual(typeof json.email, 'string', 'Property email is a string');

        //assert password
        assert.ok(json.hasOwnProperty('password'), 'Password exists.');
        assert.equal(json['password'], user.password, 'expected password')
        assert.strictEqual(typeof json.password, 'string', 'Property password is a string.');

        //access token
        assert.ok(json.hasOwnProperty('accessToken'), 'access token exists');
        let accessToken = json['accessToken'] // get token;
        assert.strictEqual(typeof json['accessToken'], 'string', 'Property accessToken is string.');

        //id
        assert.ok(json.hasOwnProperty('_id'), 'id exists');
        let id = json['_id']; //get user id
        assert.strictEqual(typeof json['_id'], 'string', 'Property _id is a string');

        token = json['accessToken']; // get token;
        userId = json['_id']; // get userId
        sessionStorage.setItem('game-user', JSON.stringify(user)); //set token to session store in browser

        token = json['accessToken']; // get token;
        userId = json['_id']; // get userId
        sessionStorage.setItem('game-user', JSON.stringify(user)); //set token to session store in browser


    });
});

QUnit.module('game functionalities', () => {
    QUnit.test('get all games', async (assert) => {
        let path = 'data/games';
        let queryParams = '?sortBy=_createdOn%20desc';

        response = await fetch(baseUrl + path + queryParams);
        let json = await response.json();
    

        assert.ok(response.ok, 'successfull response');
        assert.true(Array.isArray(json), 'Response is an Array of objects');

        json.forEach(jsonProperty => {

            // _ownerId
            assert.ok(jsonProperty.hasOwnProperty('_ownerId'), 'Property _ownerId exists.');
            assert.strictEqual(typeof jsonProperty['_ownerId'], 'string', 'Property _ownerId is string.');

            // title
            assert.ok(jsonProperty.hasOwnProperty('title'), 'Property title exists.');
            assert.strictEqual(typeof jsonProperty['title'], 'string', 'Property title is string.');

            // category
            assert.ok(jsonProperty.hasOwnProperty('category'), 'Property category exists.');
            assert.strictEqual(typeof jsonProperty['category'], 'string', 'Property category is string.');

            // maxLevel
            assert.ok(jsonProperty.hasOwnProperty('maxLevel'), 'Property maxLevel exists.');
            assert.strictEqual(typeof jsonProperty['maxLevel'], 'string', 'Property maxLevel is string.');

            // imageUrl
            assert.ok(jsonProperty.hasOwnProperty('imageUrl'), 'Property imageUrl exists.');
            assert.strictEqual(typeof jsonProperty['imageUrl'], 'string', 'Property imageUrl is string.');

            // summary
            assert.ok(jsonProperty.hasOwnProperty('summary'), 'Property summary exists.');
            assert.strictEqual(typeof jsonProperty['summary'], 'string', 'Property summary is string.');

            // createdOn -> check if exists and if it is a num
            assert.ok(jsonProperty.hasOwnProperty('_createdOn'), 'Property _createdOn exists.');
            assert.strictEqual(typeof jsonProperty['_createdOn'], 'number', 'Property _createdOn is string.');

            // id -> check if exists and if it is string
            assert.ok(jsonProperty.hasOwnProperty('_id'), 'Property _id exists.')
            assert.strictEqual(typeof jsonProperty['_id'], 'string', 'Property _id is a string');
        }

        )
    });

    QUnit.test('create game functuonality', async (assert) => {
        let path = 'data/games';

        let random = Math.floor(Math.random() * 10000);
        let title = `Random game title_${random}`;
        let category = `Category random`;
        let summary = `Short random summery of ${title}`;

        game.title = title;
        game.category = category;
        game.summary = summary;

        response = await fetch(baseUrl + path, {
            method: "POST",
            headers : {
            'content-type' : 'application/json',
            'X-Authorization' : token
            },
            body: JSON.stringify(game)
        });

        assert.ok(response.ok, 'successfull response');
        let json = await response.json(); 
        console.log(json);
        
        assert.ok(json.hasOwnProperty('category'), 'Property category exists');
        assert.strictEqual(typeof json['category'], 'string', 'Property category is string');
        assert.ok(json.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
        assert.strictEqual(typeof json['imageUrl'], 'string', 'Property imageUrl is string');       
        assert.ok(json.hasOwnProperty('maxLevel'), 'Property maxLevel exists');
        assert.strictEqual(typeof json['maxLevel'], 'string', 'Property maxLevel is string');
        assert.ok(json.hasOwnProperty('summary'), 'Property summary exists');
        assert.strictEqual(typeof json['summary'], 'string', 'Property summary is string');
        assert.ok(json.hasOwnProperty('title'), 'Property title exists');
        assert.strictEqual(typeof json['title'], 'string', 'Property title is string');
        assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', 'Property _createdOn is string.'); 
        assert.ok(json.hasOwnProperty('_id'), 'Property _id exists.');
        assert.strictEqual(typeof json['_id'], 'string', 'Property _id is string');
        assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists.');
        assert.strictEqual(typeof json['_ownerId'], 'string', 'Property _ownerId is string.');

        lastCreatedGameId = json['_id'];
    });

    QUnit.test('check get game by Id functionality', async (assert) => {
        let path = 'data/games/';
        
        response = await fetch(baseUrl + path + lastCreatedGameId, {
            method : "GET"
        });

        assert.ok(response.ok, 'Response is successfull');
        let json = await response.json();

        assert.ok(json.hasOwnProperty('category'), 'Property category exists');
        assert.strictEqual(typeof json['category'], 'string', 'Property category is string');
        assert.equal(json['category'], game.category, 'Game category is expected.');
        assert.ok(json.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
        assert.strictEqual(typeof json['imageUrl'], 'string', 'Property imageUrl is string');       
        assert.ok(json.hasOwnProperty('maxLevel'), 'Property maxLevel exists');
        assert.strictEqual(typeof json['maxLevel'], 'string', 'Property maxLevel is string');
        assert.ok(json.hasOwnProperty('summary'), 'Property summary exists');
        assert.strictEqual(typeof json['summary'], 'string', 'Property summary is string');
        assert.equal(json['summary'], game.summary,'Game summary is expected.');
        assert.ok(json.hasOwnProperty('title'), 'Property title exists');
        assert.strictEqual(typeof json['title'], 'string', 'Property title is string');
        assert.equal(json['title'], game.title, 'Game title is expected');
        assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', 'Property _createdOn is string.'); 
        assert.ok(json.hasOwnProperty('_id'), 'Property _id exists.');
        assert.strictEqual(typeof json['_id'], 'string', 'Property _id is string');
        assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists.');
        assert.strictEqual(typeof json['_ownerId'], 'string', 'Property _ownerId is string.');

        

    });

    QUnit.test('edit game functionality', async (assert) => {
        //title, category, maxLevel, summary

        let path = 'data/games/';
        let random = Math.floor(Math.random() * 10000);
        let editedTitle = `Edited Random game title_${random}`;
        let editedCategory = `Edited category ${random}`;
        let editedMaxLevel = '100';
        let editedSummary = `Edited summary of ${editedTitle}`;
    
        game.title = editedTitle;
        game.category = editedCategory;
        game.maxLevel = editedMaxLevel;
        game.summary = editedSummary;

        response = await fetch(baseUrl + path + lastCreatedGameId, {
            method : 'PUT',
            headers :{
                'content-type' : 'application/json',
                'X-Authorization' : token
            }, 
            body: JSON.stringify(game)
        });

        assert.ok(response.ok, 'Game is updated successfully.');
        let json = await response.json();
        assert.ok(json.hasOwnProperty('category'), 'Property category exists');
        assert.strictEqual(typeof json['category'], 'string', 'Property category is string');
        assert.equal(json['category'], game.category, 'Game category is expected.');
        assert.ok(json.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
        assert.strictEqual(typeof json['imageUrl'], 'string', 'Property imageUrl is string');       
        assert.ok(json.hasOwnProperty('maxLevel'), 'Property maxLevel exists');
        assert.strictEqual(typeof json['maxLevel'], 'string', 'Property maxLevel is string');
        assert.ok(json.hasOwnProperty('summary'), 'Property summary exists');
        assert.strictEqual(typeof json['summary'], 'string', 'Property summary is string');
        assert.equal(json['summary'], game.summary,'Game summary is expected.');
        assert.ok(json.hasOwnProperty('title'), 'Property title exists');
        assert.strictEqual(typeof json['title'], 'string', 'Property title is string');
        assert.equal(json['title'], game.title, 'Game title is expected');
        assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', 'Property _createdOn is string.'); 
        assert.ok(json.hasOwnProperty('_id'), 'Property _id exists.');
        assert.strictEqual(typeof json['_id'], 'string', 'Property _id is string');
        assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists.');
        assert.strictEqual(typeof json['_ownerId'], 'string', 'Property _ownerId is string.');

    });

    QUnit.test('delete game functionality', async (assert) => {
        let path = 'data/games/';

        response = await fetch(baseUrl + path+ lastCreatedGameId, {
            method : 'DELETE',
            headers: {
               'X-Authorization' : token},       
        });     
        console.log(response);
        assert.ok(response.ok, 'Game is successfully deleted');
    });
});

