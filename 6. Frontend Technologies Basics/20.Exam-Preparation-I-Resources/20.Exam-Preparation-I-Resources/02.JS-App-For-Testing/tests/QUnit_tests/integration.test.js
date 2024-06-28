QUnit.config.reorder = false;

const host = 'http://localhost:3030';

let user = {
    username: "",
    email: "",
    password: "123456",
    gender: "male"

}

QUnit.module('User functionality', async() => {
    QUnit.test('Register user', async(assert) => {
        let random = generateRandom();

        user.username = `user${random}`;
        user.email = `email${random}`;

        let path = '/users/register';

        let response = await fetch(host + path, {
            method : "POST",
            headers: {
                'content-type' : 'application/json'
            },
            body: JSON.stringify(user)
        });

        let json = await response.json();

        console.log(json);
        assert.ok(response.ok, 'User registered successfully');

        
        sessionStorage.setItem('registeredUser', JSON.stringify(user));
    });

    QUnit.test('Login user', async(assert) => {

    });

});

QUnit.module('Meme functionality', async() => {
    QUnit.test('Get all memes', async(assert) => {

    });

    QUnit.test('Create meme', async(assert) => {

    });

    QUnit.test('Edit meme', async(assert) => {

    });

    QUnit.test('Delete meme', async(assert) => {

    });
});

function generateRandom() {
    return Math.floor(Math.random() * 10000);
}