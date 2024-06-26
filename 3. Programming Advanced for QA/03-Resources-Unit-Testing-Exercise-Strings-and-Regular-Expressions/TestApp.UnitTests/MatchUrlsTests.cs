using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";
        List<string> expected = new List<string>();

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "There are no urls in this text";
        
        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.Empty);
        
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {

        // Arrange
        string text = "For more information please visit https://www.softuni.bg";
        List<string> expected = new(){ "https://www.softuni.bg" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string text = "For more information please visit https://www.softuni.bg and https://judge.softuni.org";
        List<string> expected = new List<string>() { "https://www.softuni.bg", "https://judge.softuni.org" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string text = "For more information please visit \"https://www.softuni.bg\" and \"https://judge.softuni.org\"";
        List<string> expected = new List<string>() { "https://www.softuni.bg", "https://judge.softuni.org" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
