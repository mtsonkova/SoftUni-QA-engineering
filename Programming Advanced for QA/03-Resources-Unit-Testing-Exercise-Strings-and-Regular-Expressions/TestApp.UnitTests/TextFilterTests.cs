using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    // TODO: finish the test
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = { "crap", "hell" };
        string text = "Lorem ipsum dolor sit amet.";
        string expected = "Lorem ipsum dolor sit amet.";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        //Arrange
        string[] bannedWords = { "crap", "hell" };
        string text = "Holly crap! Why don't you go to hell!!!";
        string expected = "Holly ****! Why don't you go to ****!!!";

        //Act
        string result = TextFilter.Filter(bannedWords, text);

        //Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = Array.Empty<string>();
        string text = "Lorem ipsum dolor sit amet.";
        string expected = "Lorem ipsum dolor sit amet.";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {

        //Arrange
        string[] bannedWords = { " crap", "hell " };
        string text = "Holly crap! Why don't you go to hell!!!";
        string expected = "Holly*****! Why don't you go to hell!!!";

        //Act
        string result = TextFilter.Filter(bannedWords, text);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
