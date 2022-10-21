const { assert } = require('chai');
const { lookupChar } = require('./lookupChar');

describe('LookupChar Cheker', () => {
    it('should return undefined when string is incorrect type', () => {
        assert.equal(lookupChar(1, 0), undefined);
    });
    it('should return undefined when index is incorrect type', () => {
        assert.equal(lookupChar('text', 2.2), undefined);
    });
    it('should return exception when index is bigger or equal to string length', () => {
        assert.equal(lookupChar('text', 4), 'Incorrect index');
        assert.equal(lookupChar('text', 5), 'Incorrect index');
    });
    it('should return exception when index is smaller than zero', () => {
        assert.equal(lookupChar('text', -4), 'Incorrect index');
    });
    it('should return a char from the string', () => {
        assert.equal(lookupChar('text', 1), "e");
    });

});