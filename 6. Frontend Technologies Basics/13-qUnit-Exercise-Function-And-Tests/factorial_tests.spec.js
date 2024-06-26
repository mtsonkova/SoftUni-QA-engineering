const {factorial} = require('./test_functions.js');

QUnit.module('Factorial function tests', () => {
    QUnit.test('Test factorial with 5 should return 120', function(assert) {
        assert.equal(factorial(5), 120, 'Test factorial with 5 should return 120');
    });

    QUnit.test('Test factorial with 0 should return 1', function(assert) {
        assert.equal(factorial(0), 1, 'Test factorial with 0 should return 1');
    });

    QUnit.test('Test factorial with -1 should return 1', function(assert) {
        assert.equal(factorial(-1), 1, 'Test factorial with -1 should return 1');
    });
})