const { assert } = require('chai');
const { StringBuilder } = require('./StringBuilder');

describe('StringBuilder Checker', () => {

    //checking constructor functionality
    it('should return correct string', () => {
        assert.equal(new StringBuilder('someString').toString(), 'someString');
    });
    it('when string is undefined should return empty string', () => {
        assert.equal(new StringBuilder().toString(), '');
    });
    it('should throw exception when string is different type', () => {
        assert.throw(() => new StringBuilder(1), 'Argument must be a string');
        assert.throw(() => new StringBuilder([1, 2, 3]), 'Argument must be a string');
        assert.throw(() => new StringBuilder({}), 'Argument must be a string');
        assert.throw(() => new StringBuilder(true), 'Argument must be a string');
    });

    //checking append functionality
    it('should throw exception when string is different type', () => {
        assert.throw(() => new StringBuilder('').append(1), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').append([1, 2, 3]), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').append({}), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').append(true), 'Argument must be a string');
    });
    it('append should work correctly', () => {

        const instance = new StringBuilder('');
        instance.append('someText');
        assert.equal(instance.toString(), 'someText');

        instance.append('anotherText');
        assert.equal(instance.toString(), 'someTextanotherText');

    });

    //checking prepend functionality
    it('should throw exception when string is different type', () => {
        assert.throw(() => new StringBuilder('').prepend(1), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').prepend([1, 2, 3]), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').prepend({}), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').prepend(true), 'Argument must be a string');
    });
    it('prepend should work correctly', () => {

        const instance = new StringBuilder('');
        instance.prepend('someText');
        assert.equal(instance.toString(), 'someText');

        instance.prepend('anotherText');
        assert.equal(instance.toString(), 'anotherTextsomeText');

    });

    //checking insertAt functionality
    it('should throw exception when string is different type', () => {
        assert.throw(() => new StringBuilder('').insertAt(1, 0), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').insertAt([1, 2, 3], 0), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').insertAt({}, 0), 'Argument must be a string');
        assert.throw(() => new StringBuilder('').insertAt(true, 0), 'Argument must be a string');
    });
    it('insertAt should work correctly', () => {

        const instance = new StringBuilder('0123');
        instance.insertAt('someText', 1);
        assert.equal(instance.toString(), '0someText123');

        instance.insertAt('anotherText', 12);
        assert.equal(instance.toString(), '0someText123anotherText');

    });

    //checking remove functionality
    it('remove should work correctly', () => {

        const instance = new StringBuilder('0123');
        instance.remove(0, 1);
        assert.equal(instance.toString(), '123');

        instance.remove(2, 1);
        assert.equal(instance.toString(), '12');

    });

    //checking toString functionality
    it('toString should work correctly', () => {

        const instance = new StringBuilder('0123');
        assert.equal(instance.toString(), '0123');

    });

    //checking _vrfyParam functionality
    it('_vrfyParam should work correctly', () => {

        assert.throw(() => StringBuilder._vrfyParam(1), 'Argument must be a string');
        assert.throw(() => StringBuilder._vrfyParam([]), 'Argument must be a string');
        assert.throw(() => StringBuilder._vrfyParam({}), 'Argument must be a string');
        assert.throw(() => StringBuilder._vrfyParam(true), 'Argument must be a string');
    });

    //checking all methods functionality
    it('should work with all methods', () => {
        const instance = new StringBuilder('text');

        instance.append('A'); // textA
        instance.prepend('B'); // BtextA
        instance.insertAt('AB', 3); // BteABxtA
        instance.remove(1, 6); // BA

        assert.equal(instance.toString(), 'BA');
    });

});