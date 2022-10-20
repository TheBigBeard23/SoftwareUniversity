const { assert } = require('chai');
const { isSymmetric } = require('./checkForSymmetry')

describe('Symmetry Checker Tests', () => {
    it('return false with a string', () => {
        assert.equal(isSymmetric('txxt'), false);
    });
    it('return false with a number', () => {
        assert.equal(isSymmetric(1), false);
    });
    it('return true with a symmetric array from strings', () => {
        assert.equal(isSymmetric(['1', '2', '2', '1']), true);
    });
    it('return false when an array does not symmetric', () => {
        assert.equal(isSymmetric(['1', '2', '3', '4']), false);
    });
    it('return true with a symmetric array from numbers', () => {
        assert.equal(isSymmetric([1, 2, 2, 1]), true);
    });
    it('return true with a symmetric odd-length array', () => {
        assert.equal(isSymmetric([1, 2, 1]), true);
    });
    it('return false with an asymmetric odd-length array', () => {
        assert.equal(isSymmetric([1, 2, 3]), false);
    });
    it('return true with an empty array', () => {
        assert.equal(isSymmetric([]), true);
    });
    it('return false with an array of mixed types', () => {
        assert.equal(isSymmetric([1, 2, 2, "1"]), false);
    });
});