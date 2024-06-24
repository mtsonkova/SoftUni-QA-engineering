QUnit.config.reorder = false;

const host = 'http://localhost:3030';
let path = '';
let accessToken = '';
let userId = ''

let user = {
    email: '',
    password: '123456'
}

let theaterEvent = {
    "author": "Random Author",
    "date": "24.06.2024",
    "title": "",
    "description": "",
    "imageUrl": "/images/2.png"
}

let eventId = '';

QUnit.module('User Functionality', () => {
    QUnit.test('Register user', async (assert) => {
        let random = Math.floor(Math.random() * 10000);
        let email = `abv${random}@abv.bg`;
        user.email = email;

        path = '/users/register';

        let response = await fetch(host + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        assert.ok(response.ok, 'successfull response');

        let json = await response.json();
     
        //email
        assert.ok(json.hasOwnProperty('email'), 'email exists');
        assert.equal(json['email'], user.email, 'expected email');
        assert.strictEqual(typeof json['email'], 'string', 'Property email is string');

        // password
        assert.ok(json.hasOwnProperty('password'), 'password exists');
        assert.equal(json['password'], user.password, 'expected password');
        assert.strictEqual(typeof json['password'], 'string', 'Property password is string');
        //_createdOn
        assert.ok(json.hasOwnProperty('_createdOn'), '_createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', 'Property _createdOn is number');

        //id
        assert.ok(json.hasOwnProperty('_id'), '_id exists');
        assert.strictEqual(typeof json['_id'], 'string', 'Property _id is string');

        //token
        assert.ok(json.hasOwnProperty('accessToken'), 'accessToken exists');
        assert.strictEqual(typeof json['accessToken'], 'string', 'Property accessToken is string');

        accessToken = json['accessToken'];
        sessionStorage.setItem('theatreUser', JSON.stringify(user));
    });

    QUnit.test('Login user', async(assert) => {
      
        path = '/users/login';

        let response = await fetch(host + path, {
            method: "POST",
            headers: {'content-type' : 'application/json'},
            body: JSON.stringify(user)
        });

        assert.ok(response.ok, 'successfull response');
        let json = await response.json();
       
         //email
         assert.ok(json.hasOwnProperty('email'), 'email exists');
         assert.equal(json['email'], user.email, 'expected email');
         assert.strictEqual(typeof json['email'], 'string', 'Property email is string');
 
         // password
         assert.ok(json.hasOwnProperty('password'), 'password exists');
         assert.equal(json['password'], user.password, 'expected password');
         assert.strictEqual(typeof json['password'], 'string', 'Property password is string');
         //_createdOn
         assert.ok(json.hasOwnProperty('_createdOn'), '_createdOn exists');
         assert.strictEqual(typeof json['_createdOn'], 'number', 'Property _createdOn is number');
 
         //id
         assert.ok(json.hasOwnProperty('_id'), '_id exists');
         assert.strictEqual(typeof json['_id'], 'string', 'Property _id is string');
 
         //token
         assert.ok(json.hasOwnProperty('accessToken'), 'accessToken exists');
         assert.strictEqual(typeof json['accessToken'], 'string', 'Property accessToken is string');
 
         accessToken = json['accessToken'];
         sessionStorage.setItem('theatreUser', JSON.stringify(user));
    });

});

QUnit.module('Event functionality', () => {
    QUnit.test('Get all events', async(assert) => {
        let path = '/data/theaters?sortBy=_createdOn%20desc&distinct=title';

        let response = await fetch(host + path);

        assert.ok(response.ok, 'successfill response');

        let json = await response.json();
          
        assert.true(Array.isArray(json), 'response is array');

        json.forEach(element => {
            //author
            assert.ok(element.hasOwnProperty('author'), 'author exists');
            assert.strictEqual(typeof element['author'], 'string', 'Property author is string');
            assert.true(element['author'].length > 0, 'element author is not empty string');

            // date
            assert.ok(element.hasOwnProperty('date'), 'date exists');
            assert.strictEqual(typeof element['date'], 'string', 'Property date is string');
            assert.true(element['date'].length > 0, 'element date is not empty string');
            
            //description
            assert.ok(element.hasOwnProperty('description'), 'description exists');
            assert.strictEqual(typeof element['description'], 'string', 'Property description is string');
            assert.true(element['description'].length > 0, 'element description is not empty string');

            //imageUrl
            assert.ok(element.hasOwnProperty('imageUrl'), 'imageUrl exists');
            assert.strictEqual(typeof element['imageUrl'], 'string', 'Property imageUrl is string');
            assert.true(element['imageUrl'].length > 0, 'element imageUrl is not empty string');
            
            //title
            assert.ok(element.hasOwnProperty('title'), 'title exists');
            assert.strictEqual(typeof element['title'], 'string', 'Property title is string');
            assert.true(element['title'].length > 0, 'element title is not empty string');
            
            //_createdOn number
            assert.ok(element.hasOwnProperty('_createdOn'), '_createdOn exists');
            assert.strictEqual(typeof element['_createdOn'], 'number', 'Property _createdOn is string');
            assert.true(element['_createdOn'] > 0, 'element title is greater than 0');
           
            //_id
            assert.ok(element.hasOwnProperty('_id'), '_id exists');
            assert.strictEqual(typeof element['_id'], 'string', 'Property _id is string');
            assert.true(element['_id'].length > 0, 'element _id is not empty string');

            //_ownerId
            assert.ok(element.hasOwnProperty('_ownerId'), '_ownerId exists');
            assert.strictEqual(typeof element['_ownerId'], 'string', 'Property _ownerId is string');
            assert.true(element['_ownerId'].length > 0, 'element _ownerId is not empty string');
        });

        QUnit.test('Create event', async(assert) => {
            path = '/data/theaters';

            //author, title, description
            let random = Math.floor(Math.random() * 10000);

          
            let title = `random_title_${random}`;
            let description = `random_description_${random}`;

            theaterEvent.title = title;
            theaterEvent.description = description;

            let response = await fetch(host + path, {
                method: "POST",
                headers: {
                    'content-type': 'application/json',
                    'X-Authorization': accessToken
                },
                body: JSON.stringify(theaterEvent)
            });

            assert.ok(response.ok, 'successfull creation of event');

            let json = await response.json();
            console.log(json);

            //author
            assert.ok(json.hasOwnProperty('author'), 'Property author exists');
            assert.equal(json['author'], theaterEvent.author, 'Author is expected');
            assert.strictEqual(typeof json['author'], 'string', 'Property author is a string');

            //date
            assert.ok(json.hasOwnProperty('date'), 'Property date exists');
            assert.strictEqual(typeof json['date'], 'string', 'Property date is a string');
            assert.true(json['author'].length > 0, 'Date is not empty string');

            //description
            assert.ok(json.hasOwnProperty('description'), 'Property description exists');
            assert.equal(json['description'], theaterEvent.description, 'Description is expected');
            assert.strictEqual(typeof json['description'], 'string', 'Property description is a string');

            //imageUrl
            assert.ok(json.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
            assert.strictEqual(typeof json['imageUrl'], 'string', 'Property imageUrl is a string');
            assert.true(json['imageUrl'].length > 0, 'imageUrl is not empty string');

            //title
            assert.ok(json.hasOwnProperty('title'), 'Property title exists');
            assert.equal(json['title'], theaterEvent.title, 'Title is expected');
            assert.strictEqual(typeof json['title'], 'string', 'Property title is a string');

            //_createdOn
            assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
            assert.strictEqual(typeof json['_createdOn'], 'number', 'Property imageUrl is a number');
            assert.true(json['_createdOn'] > 0, '_createdOn is > 0');

            //_id
            assert.ok(json.hasOwnProperty('_id'), 'Property _id exists');
            assert.strictEqual(typeof json['_id'], 'string', 'Property _id is a string');
            assert.true(json['_id'].length > 0, '_id is not empty string');

            //_ownerId
            assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
            assert.strictEqual(typeof json['_ownerId'], 'string', 'Property_ownerId is a string');
            assert.true(json['_ownerId'].length > 0, '_ownerId is not empty string');

            eventId = json['_id'];
        });

        QUnit.test('Edit event', async(assert) => {
            
            path = `/data/theaters/${eventId}`;

            console.log(host + path)
           
            let random = Math.floor(Math.random() * 10000);

            theaterEvent.author = 'Edited Random Author';
            theaterEvent.title = `edited_random_title_${random}`;
            theaterEvent.description = `edited_random_description_${random}`;

            let response = await fetch(host + path, {
                method: 'PUT',
                headers: {
                    'content-type' : 'application/json',
                    'X-Authorization' : accessToken
                },
                body: JSON.stringify(theaterEvent)
            });

            assert.ok(response.ok, 'successfull response');

            let json = await response.json();
            
             //author
             assert.ok(json.hasOwnProperty('author'), 'Property author exists');
             assert.equal(json['author'], theaterEvent.author, 'Author is expected');
             assert.strictEqual(typeof json['author'], 'string', 'Property author is a string');
 
             //date
             assert.ok(json.hasOwnProperty('date'), 'Property date exists');
             assert.strictEqual(typeof json['date'], 'string', 'Property date is a string');
             assert.true(json['author'].length > 0, 'Date is not empty string');
 
             //description
             assert.ok(json.hasOwnProperty('description'), 'Property description exists');
             assert.equal(json['description'], theaterEvent.description, 'Description is expected');
             assert.strictEqual(typeof json['description'], 'string', 'Property description is a string');
 
             //imageUrl
             assert.ok(json.hasOwnProperty('imageUrl'), 'Property imageUrl exists');
             assert.strictEqual(typeof json['imageUrl'], 'string', 'Property imageUrl is a string');
             assert.true(json['imageUrl'].length > 0, 'imageUrl is not empty string');
 
             //title
             assert.ok(json.hasOwnProperty('title'), 'Property title exists');
             assert.equal(json['title'], theaterEvent.title, 'Title is expected');
             assert.strictEqual(typeof json['title'], 'string', 'Property title is a string');
 
             //_createdOn
             assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
             assert.strictEqual(typeof json['_createdOn'], 'number', 'Property imageUrl is a number');
             assert.true(json['_createdOn'] > 0, '_createdOn is > 0');
 
             //_id
             assert.ok(json.hasOwnProperty('_id'), 'Property _id exists');
             assert.strictEqual(typeof json['_id'], 'string', 'Property _id is a string');
             assert.true(json['_id'].length > 0, '_id is not empty string');
 
             //_ownerId
             assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
             assert.strictEqual(typeof json['_ownerId'], 'string', 'Property_ownerId is a string');
             assert.true(json['_ownerId'].length > 0, '_ownerId is not empty string');
        });

        QUnit.test('Delete event', async(assert) => {
            path = `/data/theaters/${eventId}`;

            let response = await fetch(host + path, {
                method: "DELETE",
                headers: {
                'X-Authorization' : accessToken}
            });

            assert.ok(response.ok, 'event deleted successfully');

        });
    })
})


