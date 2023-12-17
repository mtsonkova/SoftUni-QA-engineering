using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class NumberFrequencyTests
{
    [Test]
    public void Test_CountDigits_ZeroNumber_ReturnsEmptyDictionary()
    {
        // Arrange
        int num = 0;
        
        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(num);

        // Assert
        Assert.That(result, Is.Empty);

    }

    [Test]
    public void Test_CountDigits_SingleDigitNumber_ReturnsDictionaryWithSingleEntry()
    {
        // Arrange
        int num = 2;

        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(num);
        int expectedDictionaryLength = 1;
        int actualDictionaryLength = result.Count;

        // Assert
        Assert.That(actualDictionaryLength, Is.EqualTo(expectedDictionaryLength));
    }

    [Test]
    public void Test_CountDigits_MultipleDigitNumber_ReturnsDictionaryWithDigitFrequencies()
    {

        // Arrange
        int num = 22345144;

        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(num);
        Dictionary<int, int> expected = new Dictionary<int, int> {
            { 2, 2 },
            { 3, 1 },
            { 4, 3 },
            { 5, 1 },
            { 1, 1 }
        };

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CountDigits_NegativeNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        int num = -22345144;

        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(num);
        Dictionary<int, int> expected = new Dictionary<int, int> {
            { 2, 2 },
            { 3, 1 },
            { 4, 3 },
            { 5, 1 },
            { 1, 1 }
        };

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
