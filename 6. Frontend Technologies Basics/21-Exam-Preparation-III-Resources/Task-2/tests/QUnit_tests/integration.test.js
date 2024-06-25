QUnit.config.reorder = false;

const host = 'http://localhost:3030';
let path = '';
let accessToken = '';

let user = {
    email: '',
    password: '123456'
}

let book = {
    title: '',
    description: '',
    imageUrl: '/images/2.png',
    type: 'other'
}

let bookId = '';


QUnit.module('User functionality', () => {
    QUnit.test('Register testing', async (assert) => {

        path = '/users/register';

        let random = Math.floor(Math.random() * 10000);
        let email = `abv${random}@abv.bg`;
        user.email = email;

        let response = await fetch(host + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        assert.ok(response.ok, 'register user successfull');

        let json = await response.json();

        //accessToken
        assert.ok(json.hasOwnProperty('accessToken'), 'Propery accessToken exists');
        assert.strictEqual(typeof json['accessToken'], 'string', 'accessToken is string');

        //email
        assert.ok(json.hasOwnProperty('email'), 'Propery email exists');
        assert.strictEqual(typeof json['email'], 'string', 'email is string');
        assert.equal(json['email'], user.email, 'Property value is expected')

        //password
        assert.ok(json.hasOwnProperty('password'), 'Propery password exists');
        assert.strictEqual(typeof json['password'], 'string', 'password is string');
        assert.equal(json['password'], user.password, 'Property value is expected')

        //_createdOn num
        assert.ok(json.hasOwnProperty('_createdOn'), 'Propery _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', '_createdOn is number');

        //_id
        assert.ok(json.hasOwnProperty('_id'), 'Propery accessToken exists');
        assert.strictEqual(typeof json['_id'], 'string', '_id is string');

        accessToken = json['accessToken'];
        sessionStorage.setItem('book-reader', JSON.stringify(user));
    });

    QUnit.test('Login testing', async (assert) => {
        path = '/users/login';

        let response = await fetch(host + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        assert.ok(response.ok, 'Login is successfull');

        let json = await response.json();

        //accessToken
        assert.ok(json.hasOwnProperty('accessToken'), 'Propery accessToken exists');
        assert.strictEqual(typeof json['accessToken'], 'string', 'accessToken is string');

        //email
        assert.ok(json.hasOwnProperty('email'), 'Propery email exists');
        assert.strictEqual(typeof json['email'], 'string', 'email is string');
        assert.equal(json['email'], user.email, 'Property value is expected')

        //password
        assert.ok(json.hasOwnProperty('password'), 'Propery password exists');
        assert.strictEqual(typeof json['password'], 'string', 'password is string');
        assert.equal(json['password'], user.password, 'Property value is expected')

        //_createdOn num
        assert.ok(json.hasOwnProperty('_createdOn'), 'Propery _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', '_createdOn is number');

        //_id
        assert.ok(json.hasOwnProperty('_id'), 'Propery accessToken exists');
        assert.strictEqual(typeof json['_id'], 'string', '_id is string');


        accessToken = json['accessToken'];
        sessionStorage.setItem('book-reader', JSON.stringify(user));
    });
});

QUnit.module('Book functionality', () => {
    QUnit.test('Get all books', async (assert) => {
        path = '/data/books';
        let queryParams = '?sortBy=_createdOn%20desc';

        let response = await fetch(host + path + queryParams, {
            nethod: "GET"
        });

        assert.ok(response.ok, 'Get all books successfull');
        let json = await response.json();
       
        json.forEach(book => {
            //description
            assert.ok(book.hasOwnProperty('description'), 'Property description exists');
            assert.strictEqual(typeof book['description'], 'string', 'Description is string.');

            //imageUrl
            assert.ok(book.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
            assert.strictEqual(typeof book['imageUrl'], 'string', 'imageUrl is string.');

            //title
            assert.ok(book.hasOwnProperty('title'), 'Property title exists');
            assert.strictEqual(typeof book['title'], 'string', 'title is string.');

            //type
            assert.ok(book.hasOwnProperty('type'), 'Property type exists');
            assert.strictEqual(typeof book['type'], 'string', 'type is string.');

            //_createdOn
            assert.ok(book.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
            assert.strictEqual(typeof book['_createdOn'], 'number', '_createdOn is string.');

            //_id
            assert.ok(book.hasOwnProperty('_id'), 'Property _id exists');
            assert.strictEqual(typeof book['_id'], 'string', '_id is string.');

            //_ownerId
            assert.ok(book.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
            assert.strictEqual(typeof book['_ownerId'], 'string', '_ownerId is string.');
        });

    });

    QUnit.test('Create book', async (assert) => {

        path = '/data/books';

        let random = Math.floor(Math.random() * 10000);

        let title = `random_title_${random}`;
        let description = `random_description_${random}`;

        book.title = title;
        book.description = description;

        let response = await fetch(host + path, {
            method: "POST",
            headers: {
                'content-type' : 'application/json',
                'X-Authorization' : accessToken 
            },
            body: JSON.stringify(book)
        });

        assert.ok(response.ok, 'books is created successfully');

        let json = await response.json();
       
        //description
        assert.ok(json.hasOwnProperty('description'), 'Property description exists');
        assert.strictEqual(typeof json['description'], 'string', 'Description is string.');
        assert.equal(json['description'], book.description, 'Property description has expected value')

        //imageUrl
        assert.ok(json.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
        assert.strictEqual(typeof json['imageUrl'], 'string', 'imageUrl is string.');

        //title
        assert.ok(json.hasOwnProperty('title'), 'Property title exists');
        assert.strictEqual(typeof json['title'], 'string', 'title is string.');
        assert.equal(json['title'], book.title, 'Property title has expected value')

        //type
        assert.ok(json.hasOwnProperty('type'), 'Property type exists');
        assert.strictEqual(typeof json['type'], 'string', 'type is string.');

        //_createdOn
        assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', '_createdOn is string.');

        //_id
        assert.ok(json.hasOwnProperty('_id'), 'Property _id exists');
        assert.strictEqual(typeof json['_id'], 'string', '_id is string.');

        //_ownerId
        assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
        assert.strictEqual(typeof json['_ownerId'], 'string', '_ownerId is string.');

        bookId = json['_id'];
    });

    QUnit.test('Edit book', async (assert) => {
        path = '/data/books/';

        let random = Math.floor(Math.random() * 10000);

        let editedTitle = `Edited_random_title_${random}`;
        let editedDescription = `Edited_random_description_${random}`;

        book.title = editedTitle;
        book.description = editedDescription;

        let response = await fetch(host + path + bookId, {
            method: "PUT",
            headers: {
                'content-type' : 'application/json',
                'X-Authorization' : accessToken
            },
            body: JSON.stringify(book)
        });

        assert.ok(response.ok, 'Book updated successfully');

        let json = await response.json();

        //description
        assert.ok(json.hasOwnProperty('description'), 'Property description exists');
        assert.strictEqual(typeof json['description'], 'string', 'Description is string.');
        assert.equal(json['description'], book.description, 'Property description has expected value')

        //imageUrl
        assert.ok(json.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
        assert.strictEqual(typeof json['imageUrl'], 'string', 'imageUrl is string.');

        //title
        assert.ok(json.hasOwnProperty('title'), 'Property title exists');
        assert.strictEqual(typeof json['title'], 'string', 'title is string.');
        assert.equal(json['title'], book.title, 'Property title has expected value')

        //type
        assert.ok(json.hasOwnProperty('type'), 'Property type exists');
        assert.strictEqual(typeof json['type'], 'string', 'type is string.');

        //_createdOn
        assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', '_createdOn is string.');

        //_id
        assert.ok(json.hasOwnProperty('_id'), 'Property _id exists');
        assert.strictEqual(typeof json['_id'], 'string', '_id is string.');

        //_ownerId
        assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
        assert.strictEqual(typeof json['_ownerId'], 'string', '_ownerId is string.');


    });

    QUnit.test('Delete book', async (assert) => {
        let path = '/data/books/';

        let response = await fetch(host + path + bookId, {
            method:"DELETE",
            headers: {
                'X-Authorization' : accessToken
            }
        });

        assert.ok(response.ok, 'Book is deleted successfully');
    });


});