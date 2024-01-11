using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class CharacterRangeTests
{
    char charOne = '0';
    char charTwo = '0';
    string result = "";
    string expected = "";

    [Test]
    public void Test_GetRange_WithAAndBInOrder_ReturnsEmptyString()
    {
        // arrange
        char charOne = 'A';
        char charTwo = 'B';
        expected = string.Empty;
        
        // act
        result = CharacterRange.GetRange(charOne, charTwo);
        
        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetRange_WithBAndAInOrder_ReturnsEmptyString()
    {
        // arrange
        char charOne = 'B';
        char charTwo = 'A';
        expected = string.Empty;

        // act
        result = CharacterRange.GetRange(charOne, charTwo);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetRange_WithAAndCInOrder_ReturnsB()
    {
        // arrange
        char charOne = 'A';
        char charTwo = 'C';
        expected = "B";

        // act
        result = CharacterRange.GetRange(charOne, charTwo);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetRange_WithDAndGInOrder_Returns_E_F()
    {
        // arrange
        char charOne = 'D';
        char charTwo = 'G';
        expected = "E F";

        // act
        result = CharacterRange.GetRange(charOne, charTwo);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y()
    {
        // arrange
        char charOne = 'X';
        char charTwo = 'Z';
        expected = "Y";

        // act
        result = CharacterRange.GetRange(charOne, charTwo);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
