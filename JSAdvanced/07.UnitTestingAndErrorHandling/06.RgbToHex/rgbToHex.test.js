const { assert } = require('chai');
const { rgbToHexColor } = require('./rgbToHex');

describe('RGB to HEX Converter Checker', () => {
    it('convert RGB value to Hex color code correctly', () => {
        assert.equal(rgbToHexColor(52, 235, 58), '#34EB3A');
    });
    it('convert RGB value of red color to Hex color code correctly', () => {
        assert.equal(rgbToHexColor(255, 0, 0), '#FF0000');
    });
    it('return undefined with out of range RGB value', () => {
        assert.equal(rgbToHexColor(256, 0, 0), undefined);
        assert.equal(rgbToHexColor(-1, 0, 0), undefined);
    });
    it('return undefined with incorrect type params for RGB value', () => {
        assert.equal(rgbToHexColor('255', '0', '0'), undefined);
    });
    it('return undefined with missing params', () => {
        assert.equal(rgbToHexColor(), undefined);
        assert.equal(rgbToHexColor(0), undefined);
        assert.equal(rgbToHexColor(0, 0), undefined);
    });
})


