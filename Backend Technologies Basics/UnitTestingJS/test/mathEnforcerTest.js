import { expect } from "chai";
import { mathEnforcer } from "./mathEnforcer.js";

const{addFive, subtractTen, sum} = mathEnforcer;

describe('mathEnforcer', () => {
    describe('sum', () => {
        it('sum two negative numbers should return negative number', () => {
            expect(sum(-10, -20)).to.equal(-30);
        });
        it('sum two positive numbers should return positive number', () => {
            expect(sum(10, 20)).to.equal(30);
        });
        it('sum two positive floating point numbers should return a floating point number', () => {
            expect(sum(2.58, 5.5)).to.equal(8.08);
        });
        it('sum two positive floating point numbers that add up to a whole number should return a whole number', () => {
            expect(sum(2.5, 2.5)).to.equal(5);
        });
        it('sum positive with bigger negative num should return a negative num', () => {
            expect(sum(3, - 5.2)).to.greaterThanOrEqual(-2.2);
        });
        it('sum negative with bigger positive num should return a positive num', () => {
            expect(sum(3, - 5.2)).to.greaterThanOrEqual(-2.2);
        });

        it('sum 2 numbers when second number is undefined', () => {
            //arrange 
            const firstNum = 5;
            const secondNum = undefined;

            // act 
            const result = sum(firstNum, secondNum);

            // assert

            expect(result).to.equal(undefined);
        });

        it('sum 2 numbers when second number is string', () => {
            //arrange 
            const firstNum = 5;
            const secondNum = 'abc';

            // act 
            const result = sum(firstNum, secondNum);

            // assert

            expect(result).to.equal(undefined);
        });

        it('sum 2 numbers when 1st num is undefined and second is array of nums', () => {
            //arrange 
            const firstNum = undefined;
            const secondNum = [2, 4.5, -12, 0, -1.8, 5];

            // act 
            const result = sum(firstNum, secondNum);

            // assert

            expect(result).to.equal(undefined);
        });

    });


    describe('subtractTen', () => {
        it('try to subtract 10 from negative number', () => {
            expect(subtractTen(-10)).to.equal(-20);
        });
    })
})