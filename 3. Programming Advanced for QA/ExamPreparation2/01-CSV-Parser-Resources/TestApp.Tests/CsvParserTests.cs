using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        string text = "";

        // Act
        string[] result = CsvParser.ParseCsv(text);
        
        // Assert
        Assert.That(result, Is.Empty);

    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        string text = "lorem";

        // Act
        string[] result = CsvParser.ParseCsv(text);

        // Assert
        Assert.That(result.Length, Is.EqualTo(1));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        string text = "lorem ipsum dolor sit amet";
        string[] expected = { "lorem ipsum dolor sit amet" };
        // Act
        string[] result = CsvParser.ParseCsv(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        // Arrange
        string text = "  lorem   ipsum dolor  sit    amet      ";
        string[] expected = { "lorem   ipsum dolor  sit    amet" };
        
        // Act
        string[] result = CsvParser.ParseCsv(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
