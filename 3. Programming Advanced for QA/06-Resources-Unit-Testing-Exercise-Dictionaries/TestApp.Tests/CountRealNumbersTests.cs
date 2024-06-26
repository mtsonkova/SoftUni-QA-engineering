using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // TODO: finish test
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        string result = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = { 4 };
        string expected = "4 -> 1";
        // Act
        string result = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = { 4, 6, 8, 3, 8, 1, 1, 1 };
        string expected = "1 -> 3\r\n3 -> 1\r\n4 -> 1\r\n6 -> 1\r\n8 -> 2";
        // Act
        string result = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = { 4, 6, -8, 3, -8, -1, -1, -1 };
        string expected = "-8 -> 2\r\n-1 -> 3\r\n3 -> 1\r\n4 -> 1\r\n6 -> 1";
        // Act
        string result = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = {0, 1, 1 };
        string expected = "0 -> 1\r\n1 -> 2";
        // Act
        string result = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
