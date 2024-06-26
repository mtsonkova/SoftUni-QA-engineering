using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

   
    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new(){"a"};
        string expected = "a -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "aabbbc" };
        string expected = "a -> 2\r\nb -> 3\r\nc -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "!#@@bbc" };
        string expected = "! -> 1\r\n# -> 1\r\n@ -> 2\r\nb -> 2\r\nc -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
