using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Miner.Mine(input);
        // Assert
        Assert.That(result, Is.Empty);

    }

    // TODO: finish test
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = { "GoLD 8", "SILvER 30" };

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo($"gold -> 8{Environment.NewLine}silver -> 30"));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] input = { "gold 8", "silver 30", "copper 10", "gold 22" };

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo($"gold -> 30{Environment.NewLine}silver -> 30{Environment.NewLine}copper -> 10"));
    }
}
