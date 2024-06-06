const { isEven } = require('./test_functions.js');

QUnit.module('isEven function tests', () => {
    QUnit.test('Test with even number should return true', function (assert) {
        assert.true(isEven(2), true, 'Test with even number should return true');
    });

    QUnit.test('Test with zero should return true', function (assert) {
        assert.true(isEven(0), true, 'Test with zero should return true');
    });

    QUnit.test('Test with odd number should return false', function (assert) {
        assert.false(isEven(3), false, 'Test with odd number should return false');
    });
    QUnit.test('Test with string should return false', function (assert) {
        assert.false(isEven('hello'), false, 'Test with string should return false');
    });
    QUnit.test('Test with negative even number should return true', function (assert) {
        assert.true(isEven(-4), true, 'Test with negative even number should return true');
    });
    QUnit.test('Test with negative odd number should return false', function (assert) {
        assert.false(isEven(-3), false, 'Test with negative odd number should return false');
    });
    QUnit.test('Test with even floating point number should return true', function (assert) {
        assert.true(isEven(2.46), true, 'Test with even floating point number should return true');
    });
    QUnit.test('Test with odd floating point number should return false', function (assert) {
        assert.false(isEven(3.41), false, 'Test with odd floating point number should return false');
        console.log(3.41 % 2);
    });
})