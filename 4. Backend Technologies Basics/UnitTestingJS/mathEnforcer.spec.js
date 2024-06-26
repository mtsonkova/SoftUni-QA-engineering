import { expect } from "chai";
import { mathEnforcer } from "./mathEnforcer.js";

const {addFive, subtractTen, sum} = mathEnforcer;

describe('mathEnforcer', () => {
    describe('addFive', () => {

        it('test with whole positive number', () => {
            //arrange
            let num = 10;
            let expected = 15
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with whole negative number', () => {
            //arrange
            let num = -10;
            let expected = -5
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with floating point positive number', () => {
            //arrange
            let num = 3.25;
            let expected = 8.25;
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with floating point negative number', () => {
            //arrange
            let num = -3.25;
            let expected = 1.75;
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with zero should return 5', () => {
            //arrange
            let num = 0;
            let expected = 5;
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        }); 

        it('test with -5 should return 0', () => {
            //arrange
            let num = -5;
            let expected = 0;
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with floating point num with a lot of digits after the decimal point', () => {
             //arrange
             let num = 3.234567891;
             let expected = 8.234567891;
             // act
             let actual = addFive(num);
             // assert
             expect(actual).to.be.closeTo(expected, 0.01);
        });

        it('test with empty should return undefined', () => {
            //arrange
            let num ='';
            let expected = undefined;
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with number as string should return undefined', () => {
            //arrange
            let num = '12';
            let expected = undefined;
            // act
            let actual = addFive(num);
            // assert
            expect(actual).to.equal(expected);
        });        
    });

    describe('subtractTen', () => {
        it('test with whole positive number', () => {
            //arrange
            let num = 15;
            let expected = 5
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with whole negative number', () => {
            //arrange
            let num = -5;
            let expected = -15
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with floating point positive number', () => {
            //arrange
            let num = 3.25;
            let expected = -6.75;
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with floating point negative number', () => {
            //arrange
            let num = -3.25;
            let expected = -13.25;
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with zero should return -10', () => {
            //arrange
            let num = 0;
            let expected = -10;
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        }); 

        it('test with -10 should return -20', () => {
            //arrange
            let num = -10;
            let expected = -20;
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with floating point num with a lot of digits after the decimal point', () => {
             //arrange
             let num = 3.23456;
             let expected = -6.76544;
             // act
             let actual = subtractTen(num);
             // assert
             expect(actual).to.be.closeTo(expected, 0.01);
        });

        it('test with empty should return undefined', () => {
            //arrange
            let num ='';
            let expected = undefined;
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        });

        it('test with number as string should return undefined', () => {
            //arrange
            let num = '12';
            let expected = undefined;
            // act
            let actual = subtractTen(num);
            // assert
            expect(actual).to.equal(expected);
        });
    })

    describe('sum', () => {
        it('test with two positive numbers should return positive num', () => {
            
            // Arrange
            let firstNum = 3;
            let secondNum = 5; 
            let expected = 8;
            
            // Act
            let actual = sum(firstNum, secondNum);
            
            // Assert
            expect(actual).to.equal(expected);            
        });

        it('test with positive and bigger negative numbers should return negative num', () => {
            
            // Arrange
            let firstNum = 3;
            let secondNum = -5; 
            let expected = -2;
            
            // Act
            let actual = sum(firstNum, secondNum);
            
            // Assert
            expect(actual).to.equal(expected);            
        });

        it('test with floating point numbers with a lot of digits after the decimal point should return floating point num', () => {
            
            // Arrange
            let firstNum = 3.2345678;
            let secondNum = 1.20004321; 
            let expected = 4.43461101;
            
            // Act
            let actual = sum(firstNum, secondNum);
            
            // Assert
            expect(actual).to.be.closeTo(expected, 0.01);            
        });

        it('test with two floating point numbers that add up to a whole num should return a number without decimal part', () => {
            
            // Arrange
            let firstNum = 0.5;
            let secondNum = 0.5; 
            let expected = 1;
            
            // Act
            let actual = sum(firstNum, secondNum);
            
            // Assert
            expect(actual).to.equal(expected);            
        });

        it('test with undefined and valid num should return undefined', () => {
            
            // Arrange
            let firstNum = undefined;
            let secondNum = 4; 
            let expected = undefined;
            
            // Act
            let actual = sum(firstNum, secondNum);
            
            // Assert
            expect(actual).to.equal(expected);            
        });

        it('test with string and object should return undefined', () => {
            
            // Arrange
            let firstNum = 'hello';
            let secondNum = {name: 'Samantha', age: 24}; 
            let expected = undefined;
            
            // Act
            let actual = sum(firstNum, secondNum);
            
            // Assert
            expect(actual).to.equal(expected);            
        });
        
    })
})