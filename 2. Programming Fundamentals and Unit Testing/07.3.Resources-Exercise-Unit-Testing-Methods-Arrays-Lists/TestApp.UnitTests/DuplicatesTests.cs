using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class DuplicatesTests
{
    // TODO: finish test
    [Test]
    public void Test_RemoveDuplicates_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();

        // Act
        int[] result = Duplicates.RemoveDuplicates(numbers);
        
        // Assert
        Assert.IsEmpty(result);
    }

    // TODO: finish test
    [Test]
    public void Test_RemoveDuplicates_NoDuplicates_ReturnsOriginalArray()
    {
        // Arrange
        int[] numbers = new int[] { 1, 4, 7, 8, 6, 9, 12 };
        
        // Act
        int[] result = Duplicates.RemoveDuplicates(numbers);

        // Assert
       Assert.That(result, Is.EqualTo(numbers));
    }

    [Test]
    public void Test_RemoveDuplicates_SomeDuplicates_ReturnsUniqueArray()
    {
        // Arrange
        int[] numbers = new int[] { 1, 1, 4, 4, 7, 8, 6, 9, 12, 6 };
        int[] expected = new int[] { 1, 4, 7, 8, 6, 9, 12 };

        // Act
        int[] result = Duplicates.RemoveDuplicates(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveDuplicates_AllDuplicates_ReturnsSingleElementArray()
    {
        // Arrange
        int[] numbers = new int[] { 1, 1, 1 };
        int[] expected = new int[] { 1 };

        // Act
        int[] result = Duplicates.RemoveDuplicates(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
