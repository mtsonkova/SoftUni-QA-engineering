using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        //Arrange
        string[] input = { "text" };
        string expected = "texttexttexttext";

        //Act
        string actual = RepeatStrings.Repeat(input);

        //Assert
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        //Arrange
        string[] input = { "test","qa" };
        string expected = "testtesttesttestqaqa";

        //Act
        string actual = RepeatStrings.Repeat(input);

        //Assert
        Assert.That(expected, Is.EqualTo(actual));
    }
}
