using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = Array.Empty<string>();

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = { "home", "word", "home", "word" };

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.Empty);        
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] words = { "home", "word", "home", "word", "home" };
        string expected = "home";
        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] words = { "home", "word", "home", "song", "home" };
        string expected = "home word song" ;
        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] words = { "home", "word", "hOme", "song", "HoMe" };
        string expected = "home word song";
        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
