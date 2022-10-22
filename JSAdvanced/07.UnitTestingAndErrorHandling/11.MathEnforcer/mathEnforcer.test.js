const { assert } = require('chai');
const { mathEnforcer } = require('./mathEnforcer');

describe('Math Enforcer Checker', () => {
    it('should return undefined when addFive func accepts not a number type value', () => {
        assert.isUndefined(mathEnforcer.addFive('one'));
        assert.isUndefined(mathEnforcer.addFive([]));
        assert.isUndefined(mathEnforcer.addFive({}));
        assert.isUndefined(mathEnforcer.addFive());
    });
    it('should work correctly when addFive func accepts number', () => {
        assert.equal(mathEnforcer.addFive(0), 5);
        assert.equal(mathEnforcer.addFive(1), 6);
        assert.equal(mathEnforcer.addFive(-1), 4);
        assert.equal(mathEnforcer.addFive(0.5), 5.5);

    });
    it('should return undefined when subtractTen func accepts not a number type value', () => {
        assert.isUndefined(mathEnforcer.subtractTen('one'));
        assert.isUndefined(mathEnforcer.subtractTen([]));
        assert.isUndefined(mathEnforcer.subtractTen({}));
        assert.isUndefined(mathEnforcer.subtractTen());
    });
    it('should work correctly when subtractTen func accepts number', () => {
        assert.equal(mathEnforcer.subtractTen(0), -10);
        assert.equal(mathEnforcer.subtractTen(10), 0);
        assert.equal(mathEnforcer.subtractTen(-10), -20);
        assert.equal(mathEnforcer.subtractTen(10.5), 0.5);
    });
    it('should return undefined when add func accepts not a number type value', () => {
        assert.isUndefined(mathEnforcer.sum('one', 2));
        assert.isUndefined(mathEnforcer.sum(2, []));
        assert.isUndefined(mathEnforcer.sum(true, 'two'));
        assert.isUndefined(mathEnforcer.sum({}, 2));

    });
    it('should work correctly when sum func accepts numbers', () => {
        assert.equal(mathEnforcer.sum(1, 2), 3);
        assert.equal(mathEnforcer.sum(0, 2), 2);
        assert.equal(mathEnforcer.sum(-1, -2), -3);
        assert.equal(mathEnforcer.sum(1.5, 0.5), 2);
    });

});