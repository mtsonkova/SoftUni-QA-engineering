using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    // TODO: finish the test cases
    [TestCase("abc", 2, "aBcaBc")]
    [TestCase("cd", 5, "cDcDcDcDcD")]
    [TestCase("Aba",3, "aBaaBaaBa")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input, 
        int repetitionFactor, string expected)
    {
        // Arrange

        // Act
        string result = Pattern.GeneratePatternedString(input, repetitionFactor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(string.Empty, 4));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString("abc", -4));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString("abc", 0));
    }
}
