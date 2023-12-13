using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        //arrange 
        string input = "";

        // act & assert
        Assert.That(StringRotator.RotateRight(input, 2), Is.Empty);
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        // arrange
        string input = "abcd";
        string expected = input;

        // act
        string result = StringRotator.RotateRight(input, 0);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        string input = "abcd";
        int position = 1;
        string expected = "dabc";
        string actual = StringRotator.RotateRight(input, position);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        string input = "abcd";
        int position = -1;
        string expected = "dabc";
        string actual = StringRotator.RotateRight(input, position);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        string input = "I am a string";
        int position = 15;
        string expected = "ngI am a stri";
        string actual = StringRotator.RotateRight(input, position);
        Assert.AreEqual(expected, actual);
    }
}
