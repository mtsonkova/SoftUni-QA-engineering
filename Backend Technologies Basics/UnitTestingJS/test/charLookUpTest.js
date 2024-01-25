import { expect } from "chai";
import { lookupChar } from "../charLookUp.js";

describe('lookupChar', () => {
    it('test with string length > 0 and valid index', () => {
        expect(lookupChar('Hello world!', 2)).to.equal('l');
    });
    it('test with string length > 0 and index < 0', () => {
        expect(lookupChar('Hello world', -5)).to.equal('Incorrect index');
    });
    it('test with string length > 0 and index > string.length', () => {
        expect(lookupChar('Hello world', 15)).to.equal('Incorrect index');
    });
    it('test with empty string and valid index', () => {
        expect(lookupChar(1, 3)).to.equal(undefined);
    });
    it('test with array of strings and valid index', () => {
        expect(lookupChar(['hi', 'everyone', 'java script', 'is', 'awesome'], 2)).to.equal(undefined);
    });
    it('test with number and valid index', () => {
        expect(lookupChar(100, 1)).to.equal(undefined);
    });
})