using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverserTests
{
    [Test]
    public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        string[] inputArray = Array.Empty<string>();

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
    {
        // Arrange
        string[] inputArray = { "Hello" };
        string[] expected = { "olleH" };

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
    {
        // Arrange
        string[] inputArray = { "Hello", "I am", "QA" };
        string[] expected = { "olleH", "ma I", "AQ" };

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
    {
        // Arrange
        string[] inputArray = { "| h@v3", "$p3c|@l", "4@r@ct3r$$" };
        string[] expected = { "3v@h |", "l@|c3p$", "$$r3tc@r@4" };

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

