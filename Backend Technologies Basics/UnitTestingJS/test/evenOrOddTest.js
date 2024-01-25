import { expect } from "chai"

import {isOddOrEven} from "../evenOrOdd.js"

describe('evenOrOdd', () => {
    it('sends string with odd length', () => {
        expect(isOddOrEven('hello')).to.equal('odd');
    });
    it('sends string with even length', () => {
        expect(isOddOrEven('hi')).to.equal('even');
    });
    it('sends empty string', () => {
        expect(isOddOrEven('')).to.equal('even');
    });
    it('sends single digit', () => {
        expect(isOddOrEven(1)).to.equal(undefined);
    });
    it('sends 2 digit number', () => {
        expect(isOddOrEven(24)).to.equal(undefined);
    })
})