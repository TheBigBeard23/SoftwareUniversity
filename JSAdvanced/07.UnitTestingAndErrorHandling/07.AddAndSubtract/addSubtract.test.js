const { assert } = require('chai');
const { createCalculator } = require('./addSubtract');

describe('Calculator  Checker', () => {

    it('should return function', () => {
        assert.equal(typeof (createCalculator), 'function');
    });
    it('should has three properties', () => {
        const calculator = createCalculator();
        assert.equal(Object.keys(calculator).length, 3);
    });
    it('function get should work correctly', () => {
        const calculator = createCalculator();
        assert.equal(calculator.get(), 0);
    });
    it('function add should work correctly', () => {
        const calculator = createCalculator();
        calculator.add(10);
        assert.equal(calculator.get(), 10);
    });
    it('function subtract should work correctly', () => {
        const calculator = createCalculator();
        calculator.add(10);
        calculator.subtract(5);
        assert.equal(calculator.get(), 5);
    });
    it('get should return NaN when add invalid params', () => {
        const calculator = createCalculator();
        calculator.add('a');
        assert.isNaN(calculator.get());
    });
    it('get should return NaN when subtract invalid params', () => {
        const calculator = createCalculator();
        calculator.subtract('a');
        assert.isNaN(calculator.get());
    });
});