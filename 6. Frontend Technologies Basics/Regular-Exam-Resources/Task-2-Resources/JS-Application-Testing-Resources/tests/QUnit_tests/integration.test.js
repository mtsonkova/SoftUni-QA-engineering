QUnit.config.reorder = false;

const host = 'http://localhost:3030';
let path = '';
let accessToken = '';

let user = {
    email: '',
    password: '123456'
}

let album = {

}

let albumId = '';

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

QUnit.module('Album functionality', () => {
    QUnit.test('Get all albums', async (assert) => {
        path = '/data/albums';
        let querySelector = '?sortBy=_createdOn%20desc&distinct=name';

        let getAllAlbumsResponse = await fetch(host + path + querySelector, {
            method: "GET"
        });

        assert.ok(getAllAlbumsResponse.ok, 'Response is successfull');

        let json = await getAllAlbumsResponse.json();

        json.forEach(element => {
            //artist
            assert.ok(element.hasOwnProperty('artist'), 'Property artist exists');
            assert.strictEqual(typeof element['artist'], 'string', 'Artist is string.');

            //description
            assert.ok(element.hasOwnProperty('description'), 'Property description exists');
            assert.strictEqual(typeof element['description'], 'string', 'Description is string.');

            //genre
            assert.ok(element.hasOwnProperty('genre'), 'Property genre exists');
            assert.strictEqual(typeof element['genre'], 'string', 'genre is string.');

            //imageUrl
            assert.ok(element.hasOwnProperty('imgUrl'), 'Property imgUrl exists');
            assert.strictEqual(typeof element['imgUrl'], 'string', 'imagUrl is string.');

            //name
            assert.ok(element.hasOwnProperty('name'), 'Property name exists');
            assert.strictEqual(typeof element['name'], 'string', 'name is string.');

            //price
            assert.ok(element.hasOwnProperty('price'), 'Property price exists');
            assert.strictEqual(typeof element['price'], 'string', 'price is string.');

            //releaseDate
            assert.ok(element.hasOwnProperty('releaseDate'), 'Property releaseDate exists');
            assert.strictEqual(typeof element['releaseDate'], 'string', 'releaseDate is string.');

            //_createdOn *num
            assert.ok(element.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
            assert.strictEqual(typeof element['_createdOn'], 'number', '_createdOn is number.');

            //_id
            assert.ok(element.hasOwnProperty('_id'), 'Property _id exists');
            assert.strictEqual(typeof element['_id'], 'string', '_id is string.');

            //_ownerId
            assert.ok(element.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
            assert.strictEqual(typeof element['_ownerId'], 'string', '_ownerId is string.');

        });
    });

    QUnit.test('Create an album', async (assert) => {
        path = '/data/albums';

        let random = Math.floor(Math.random() * 10000);
        album.name = `Album Name ${random}`;
        album.artist = `Random Album Artist ${random}`;
        album.description = `Random Album Description ${random}`;
        album.genre = `Random Album genre${random}`;
        album.imgUrl = `Random Album img${random}`;
        album.price = '$25.00';
        album.releaseDate = '12-Oct-2024';

        let createAlbumResponse = await fetch(host + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json',
                'X-Authorization': accessToken
            },
            body: JSON.stringify(album)
        });

        assert.ok(createAlbumResponse.ok, 'Response is successfull');
        let json = await createAlbumResponse.json();

        //artist
        assert.ok(json.hasOwnProperty('artist'), 'Property artist exists');
        assert.equal(json['artist'], album.artist, 'Property artist has expected value');
        assert.strictEqual(typeof json['artist'], 'string', 'Artist is string.');

        //description
        assert.ok(json.hasOwnProperty('description'), 'Property description exists');
        assert.equal(json['description'], album.description, 'Property description has expected value');
        assert.strictEqual(typeof json['description'], 'string', 'Description is string.');

        //genre
        assert.ok(json.hasOwnProperty('genre'), 'Property genre exists');
        assert.equal(json['genre'], album.genre, 'Property genre has expected value');
        assert.strictEqual(typeof json['genre'], 'string', 'genre is string.');

        //imageUrl
        assert.ok(json.hasOwnProperty('imgUrl'), 'Property imageUrl exists');
        assert.equal(json['imgUrl'], album.imgUrl, 'Property imgUrl has expected value');
        assert.strictEqual(typeof json['imgUrl'], 'string', 'imgUrl is string.');

        //name
        assert.ok(json.hasOwnProperty('name'), 'Property name exists');
        assert.equal(json['name'], album.name, 'Property name has expected value');
        assert.strictEqual(typeof json['name'], 'string', 'name is string.');

        //price
        assert.ok(json.hasOwnProperty('price'), 'Property price exists');
        assert.equal(json['price'], album.price, 'Property price has expected value');
        assert.strictEqual(typeof json['price'], 'string', 'price is string.');

        //releaseDate
        assert.ok(json.hasOwnProperty('releaseDate'), 'Property releaseDate exists');
        assert.equal(json['releaseDate'], album.releaseDate, 'Property releaseDate has expected value');
        assert.strictEqual(typeof json['releaseDate'], 'string', 'releaseDate is string.');

        //_createdOn *num
        assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', '_createdOn is number.');

        //_id
        assert.ok(json.hasOwnProperty('_id'), 'Property _id exists');
        assert.strictEqual(typeof json['_id'], 'string', '_id is string.');

        //_ownerId
        assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
        assert.strictEqual(typeof json['_ownerId'], 'string', '_ownerId is string.');

        albumId = json['_id'];             
        
    });

    QUnit.test('Edit an album', async (assert) => {
        path = '/data/albums/';

        album.description = 'Random album description is edited successfully';
        console.log(album);

        let response = await fetch(host + path + albumId, {
            method: "PUT",
            headers: {
                'content-type': 'application/json',
                'X-Authorization': accessToken
            },
            body: JSON.stringify(album)
        });

        assert.ok(response.ok, 'Album updated successfully');

        let json = await response.json();
        

        //artist
        assert.ok(json.hasOwnProperty('artist'), 'Property artist exists');
        assert.equal(json['artist'], album.artist, 'Property artist has expected value');
        assert.strictEqual(typeof json['artist'], 'string', 'Artist is string.');

        //description
        assert.ok(json.hasOwnProperty('description'), 'Property description exists');
        assert.equal(json['description'], album.description, 'Property description has expected value');
        assert.strictEqual(typeof json['description'], 'string', 'Description is string.');

        //genre
        assert.ok(json.hasOwnProperty('genre'), 'Property genre exists');
        assert.equal(json['genre'], album.genre, 'Property genre has expected value');
        assert.strictEqual(typeof json['genre'], 'string', 'genre is string.');

        //imageUrl
        assert.ok(json.hasOwnProperty('imgUrl'), 'Property imageUrl exists');
        assert.equal(json['imgUrl'], album.imgUrl, 'Property imgUrl has expected value');
        assert.strictEqual(typeof json['imgUrl'], 'string', 'imgUrl is string.');

        //name
        assert.ok(json.hasOwnProperty('name'), 'Property name exists');
        assert.equal(json['name'], album.name, 'Property name has expected value');
        assert.strictEqual(typeof json['name'], 'string', 'name is string.');

        //price
        assert.ok(json.hasOwnProperty('price'), 'Property price exists');
        assert.equal(json['price'], album.price, 'Property price has expected value');
        assert.strictEqual(typeof json['price'], 'string', 'price is string.');

        //releaseDate
        assert.ok(json.hasOwnProperty('releaseDate'), 'Property releaseDate exists');
        assert.equal(json['releaseDate'], album.releaseDate, 'Property releaseDate has expected value');
        assert.strictEqual(typeof json['releaseDate'], 'string', 'releaseDate is string.');

        //_createdOn *num
        assert.ok(json.hasOwnProperty('_createdOn'), 'Property _createdOn exists');
        assert.strictEqual(typeof json['_createdOn'], 'number', '_createdOn is number.');

        //_id
        assert.ok(json.hasOwnProperty('_id'), 'Property _id exists');
        assert.strictEqual(typeof json['_id'], 'string', '_id is string.');

        //_ownerId
        assert.ok(json.hasOwnProperty('_ownerId'), 'Property _ownerId exists');
        assert.strictEqual(typeof json['_ownerId'], 'string', '_ownerId is string.');

    });

    QUnit.test('Delete an album', async (assert) => {

        let path = '/data/albums/';
      
        let response = await fetch(host + path + albumId, {
            method: "DELETE",
            headers: {
                'X-Authorization': accessToken
            }
        });

        assert.ok(response.ok, 'Album is deleted successfully');
    });

})

