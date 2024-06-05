const {sum} = require("./test_functions.js");

QUnit.module('sum function tests', () => {
    QUnit.test('Adding two positive numbers', function(assert) {
        assert.equal(sum(2, 3,), 5, 'Adding two positive numbers');
    });

    QUnit.test('Adding positive and negative number', function(assert) {
        assert.equal(sum(2,-3,), -1, 'Adding positive and negative number');
    });

    QUnit.test('Adding positive number and zero', function(assert) {
        assert.equal(sum(2,-0,), 2, 'Adding positive number and zero');
    });

    QUnit.test('Adding positive and negative number results to zero', function(assert) {
        assert.equal(sum(2,-2,), 0, 'Adding positive and negative number results to zero');
    });

    QUnit.test('Adding two negative numbers', function(assert) {
        assert.equal(sum(-2,-2,), -4, 'Adding two negative numbers');
    });

    QUnit.test('Adding two floating point numbers - test fail', function(assert) {
        assert.equal(sum(0.1, 0.2), 3, 'Adding two floating point numbers - test fail');
    });
}) 