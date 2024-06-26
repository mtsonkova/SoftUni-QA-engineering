using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    // TODO: finish test
    [Test]
    public void Test_RemoveStringNumbers_NullInput_ThrowsException()
    {
        // Arrange
        char[]? input = null;

        // Act + Assert
        Assert.Throws<ArgumentException>(() => Fake.RemoveStringNumbers(input));
    }

    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        // Arrange
        char[]? input = new char[] {'1', 'a', 'c', '8'};
        char[] expected = new char[] { 'a', 'c' };

        // Act 
        char[] result = Fake.RemoveStringNumbers(input);
        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        // Arrange
        char[]? input = new char[] { 'z', 'a', 'c', 'k' };
        char[] expected = new char[] { 'z', 'a', 'c', 'k' };

        // Act 
        char[] result = Fake.RemoveStringNumbers(input);
        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        char[]? input = new char[] { };
        char[] expected = new char[] { };

        // Act 
        char[] result = Fake.RemoveStringNumbers(input);
        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
