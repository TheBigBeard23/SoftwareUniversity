const { PaymentPackage } = require('./PaymentPackage');
const { assert } = require('chai');

describe('PaymentPackage Checker', () => {

    //Checking name property functionality 
    it('should throw exception when name is not a string', () => {
        assert.throw(() => new PaymentPackage(1000, 1000), 'Name must be a non-empty string');
    });
    it('should throw exception when name is a empty string', () => {
        assert.throw(() => new PaymentPackage('', 1000), 'Name must be a non-empty string');
    });
    it('should throw exception when name is a empty string', () => {
        assert.throw(() => new PaymentPackage([], 1000), 'Name must be a non-empty string');
    });
    it('should return correct name', () => {
        assert.equal(new PaymentPackage('someName', 1000).name, 'someName');
    });

    //Checking value property functionality 
    it('should throw exception when value is not a number', () => {
        assert.throw(() => new PaymentPackage('someName', 'number'), 'Value must be a non-negative number');
    });
    it('should throw exception when value is not a number', () => {
        assert.throw(() => new PaymentPackage('someName', []), 'Value must be a non-negative number');
    });
    it('should throw exception when value is not a number', () => {
        assert.throw(() => new PaymentPackage('someName', -3), 'Value must be a non-negative number');
    });
    it('should return correct value', () => {
        assert.equal(new PaymentPackage('someName', 1000).value, 1000);
        assert.equal(new PaymentPackage('someName', 0).value, 0);
    });

    //Checking VAT property functionality 
    it('should throw exception when value is not a number', () => {
        assert.throw(() => new PaymentPackage('someName', 1000).VAT = '', 'VAT must be a non-negative number');
    });
    it('should throw exception when value is not a number', () => {
        assert.throw(() => new PaymentPackage('someName', 1000).VAT = [], 'VAT must be a non-negative number');
    });
    it('should throw exception when value is not a number', () => {
        assert.throw(() => new PaymentPackage('someName', 1000).VAT = -1, 'VAT must be a non-negative number');
    });
    it('should return correct VAT value', () => {
        assert.equal(new PaymentPackage('someName', 1000).VAT, 20);
        assert.equal(new PaymentPackage('someName', 1000).VAT = 100, 100);
        assert.equal(typeof new PaymentPackage('someName', 1000).VAT, 'number');

    });

    //Checking active property functionality 
    it('should return true by default', () => {
        assert.equal(new PaymentPackage('someName', 1000).active, true);
    });
    it('should return boolean', () => {
        assert.equal(typeof new PaymentPackage('someName', 1000).active, 'boolean');
    });
    it('should throw exception when active set to non-boolean type', () => {
        assert.throw(() => new PaymentPackage('someName', 1000).active = 1, 'Active status must be a boolean');
        assert.throw(() => new PaymentPackage('someName', 1000).active = [], 'Active status must be a boolean');
        assert.throw(() => new PaymentPackage('someName', 1000).active = 'string', 'Active status must be a boolean');
    });
    it('setter should work correctly', () => {
        assert.equal(new PaymentPackage('someName', 1000).active = false, false);
    });

    //Checking toString method functionality
    it('should return correct output', () => {
        assert.equal(new PaymentPackage('someName', 1000).toString(),
            `Package: someName\n- Value (excl. VAT): 1000\n- Value (VAT 20%): 1200`)
    });
    it('should return correct output', () => {
        const instance = new PaymentPackage('someName', 1000);
        instance.active = false;
        assert.equal(instance.toString(),
            `Package: someName (inactive)\n- Value (excl. VAT): 1000\n- Value (VAT 20%): 1200`)
    });

});