import { expect } from "chai";
import { lookupChar } from "./charLookup.js";

describe('lookupChar', () => {
    it('non-empty string with valid index should return the correct char', () => {
        //arrange
        let text = 'Lorem ipsum';
        let index = 1;
        let expectedChar = 'o';

        //act 
        let actualChar = lookupChar(text, index);

        //assert
        expect(actualChar).to.equal(expectedChar);
    });

    it('non-empty string with floating point index should return the correct char', () => {
        //arrange
        let text = 'Lorem ipsum';
        let index = 1.5;
        let expected = undefined;

        //act 
        let actualChar = lookupChar(text, index);

        //assert
        expect(actualChar).to.equal(expected);
    });

    it('non-empty string with index < 0 should return Incorrect index', () => {
        //arrange
        let text = 'Lorem ipsum';
        let index = -5 ;
        let expected = 'Incorrect index';

        //act 
        let actualChar = lookupChar(text, index);

        //assert
        expect(actualChar).to.equal(expected);
    });

    it('non-empty string with index > string.Length + 5 should return Incorrect index', () => {
        //arrange
        let text = 'Lorem ipsum';
        let index = text.length + 5 ;
        let expected = 'Incorrect index';

        //act 
        let actualChar = lookupChar(text, index);

        //assert
        expect(actualChar).to.equal(expected);
    });

    it('empty string with valid index should return undefined', () => {
        //arrange
        let text = '';
        let index = 5 ;
        let expected = 'Incorrect index';

        //act 
        let actualChar = lookupChar(text, index);

        //assert
        expect(actualChar).to.equal(expected);
    });
})
