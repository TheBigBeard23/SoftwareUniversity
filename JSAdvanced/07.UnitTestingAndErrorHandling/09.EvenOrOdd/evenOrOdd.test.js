const { assert } = require('chai');
const { isOddOrEven } = require('./isOddOrEven');

describe('OddOrEven Checker', () => {
    it('should return odd when string length is odd', () => {
        assert.equal(isOddOrEven('odd'), 'odd');
    });
    it('should return even when string length is odd', () => {
        assert.equal(isOddOrEven('even'), 'even');
    });
    it('should return undefined with number', () => {
        assert.isUndefined(isOddOrEven(2));
    });
    it('should return undefined with array', () => {
        assert.isUndefined(isOddOrEven(['2', '1']));
    });
});