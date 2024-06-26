import { expect } from "chai";
import { isOddOrEven } from "./oddOrEven.js";


describe('isOddOrEven', () => {
    it('send string with odd length should return odd', () => {
        //arrange
        let input = 'Hello';
        let expectedResult = 'odd';

        //act
        let actualResult = isOddOrEven(input);

        //assert
        expect(expectedResult).to.be.equal(actualResult);
    })

    it('send string with even length should return even', () => {
        //arrange
        let input = 'hi';
        let expectedResult = 'even';

        //act
        let actualResult = isOddOrEven(input);

        //assert
        expect(expectedResult).to.be.equal(actualResult);
    })

    it('send empty string should return even', () => {
        //arrange
        let input = '';
        let expectedResult = 'even';

        //act
        let actualResult = isOddOrEven(input);

        //assert
        expect(expectedResult).to.be.equal(actualResult);
    })

    it('send object should return undefined', () => {
        //arrange
        let input = {userName : "Pesho", age: 21};
        let expectedResult = undefined;

        //act
        let actualResult = isOddOrEven(input);

        //assert
        expect(expectedResult).to.be.equal(actualResult);
    })

    it('send array should return undefined', () => {
        //arrange
        let input = [1, 5, 8];
        let expectedResult = undefined;

        //act
        let actualResult = isOddOrEven(input);

        //assert
        expect(expectedResult).to.be.equal(actualResult);
    })
})