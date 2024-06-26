using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CamelCaseConverterTests
{
    [Test]
    public void Test_ConvertToCamelCase_EmptyString_ReturnsEmptyString()
    {
        // Arrange;
        string text = string.Empty;
        
        // Act & Assert
        Assert.That(CamelCaseConverter.ConvertToCamelCase(text), Is.Empty);
        // Assert
    }

    [Test]
    public void Test_ConvertToCamelCase_SingleWord_ReturnsLowercaseWord()
    {
        // Arrange
        string text = "SOFTUNIQATEST";
        string expexted = "softuniqatest";
        
        // Act
        string result = CamelCaseConverter.ConvertToCamelCase(text);

        // Assert
        Assert.That(result, Is.EqualTo(expexted));
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWords_ReturnsCamelCase()
    {
        // Arrange
        string text = "soft uni qa test";
        string expexted = "softUniQaTest";

        // Act
        string result = CamelCaseConverter.ConvertToCamelCase(text);

        // Assert
        Assert.That(result, Is.EqualTo(expexted));
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWordsWithMixedCase_ReturnsCamelCase()
    {
        // Arrange
        string text = "sOft uNi QA TeST";
        string expexted = "softUniQaTest";

        // Act
        string result = CamelCaseConverter.ConvertToCamelCase(text);

        // Assert
        Assert.That(result, Is.EqualTo(expexted));
    }
}
