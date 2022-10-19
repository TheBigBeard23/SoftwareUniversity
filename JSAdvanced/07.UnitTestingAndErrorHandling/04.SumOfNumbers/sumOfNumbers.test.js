const { assert } = require('chai');
const { sum } = require('./sumOfNumbers.js');

describe('Calculator Checker', () => {
    it('return sum of numbers in array', () => {
        assert.equal(sum([1, 2, 3]), 6);
    })
    it('return zero if array is empty', () => {
        assert.equal(sum([]), 0);
    })
    it('return NaN if array is of strings', () => {
        assert(isNaN(sum(['one', 'two', 'three'])));
    })
})
