using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    // TODO: finish test
    [Test]
    public void Test_SortInPattern_NullInput_ThrowsException()
    {
        // Arrange
        int[]? inputArray = null;

        // Act + Assert
        Assert.Throws<ArgumentException> (() => Pattern.SortInPattern (inputArray));
    }

    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        //Arrange
        int[]? inputArray = { 1, 2, 1, 3, 4, 10, 12, 15 };
        int[] expectedArray = { 1, 15, 2, 12, 3, 10, 4 };
       
        //Act
        int[] result = Pattern.SortInPattern(inputArray);

        //Assert
        Assert.That(result, Is.EqualTo(expectedArray));
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        //Arrange
        int[]? inputArray = { };
        int[] expectedArray = { };

        //Act
        int[] result = Pattern.SortInPattern(inputArray);

        //Assert
        Assert.That(result, Is.EqualTo(expectedArray));
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        //Arrange
        int[]? inputArray = { 2 };
        int[] expectedArray = { 2 };

        //Act
        int[] result = Pattern.SortInPattern(inputArray);

        //Assert
        Assert.That(result, Is.EqualTo(expectedArray));
    }
}
