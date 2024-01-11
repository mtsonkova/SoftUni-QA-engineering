using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_NumberLowerThanTwo()
    {
        //Arrange
        long num = 1;
       
        // Act& Assert
       Assert.Throws<ArgumentException>(() =>  PrimeFactor.FindLargestPrimeFactor(num));       
    }

    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        //Arrange
        long num =101;
        long expected = 101;
        // Act
        long result = PrimeFactor.FindLargestPrimeFactor(num);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        //Arrange
        long num = 345762;
        long expected = 337;
        // Act
        long result = PrimeFactor.FindLargestPrimeFactor(num);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
