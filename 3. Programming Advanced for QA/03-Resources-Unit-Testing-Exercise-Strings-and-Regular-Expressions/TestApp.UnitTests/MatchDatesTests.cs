using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class MatchDatesTests
{
    // TODO: finish the test
    [Test]
    public void Test_Match_ValidDate_ReturnsExpectedResult()
    {
        // Arrange
        string expected = "Day: 31, Month: Dec, Year: 2022";
        string dates = "31.Dec.2022";

        // Act
        string result = MatchDates.Match(dates);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish the test
    [Test]
    public void Test_Match_NoMatch_ReturnsEmptyString()
    {
        // Arrange
        string input = "Invalid date format";
        string expected = string.Empty;

        // Act
        string result = MatchDates.Match(input);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_MultipleMatches_ReturnsFirstMatch()
    {
        // Arrange
        string expected = "Day: 12, Month: Jan, Year: 2021";
        string dates = "12/Jan/2021 15-May-2020 31.Dec.2022";

        // Act
        string result = MatchDates.Match(dates);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_EmptyString_ReturnsEmptyString()
    {
        //Arrange, Act and Assert
        Assert.That(MatchDates.Match(""), Is.Empty);
    }

    [Test]
    public void Test_Match_NullInput_ThrowsArgumentException()
    {
        //Arrange
        string text = null;

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>  MatchDates.Match(text));
    }
}
