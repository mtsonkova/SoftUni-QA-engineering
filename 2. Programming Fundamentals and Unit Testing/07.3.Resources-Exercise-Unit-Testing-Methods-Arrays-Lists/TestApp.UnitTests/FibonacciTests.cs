using NUnit.Framework;

namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_NegativeInput()
    {
        // Arrange
        int n = -1;

        // Act & Assert
        Assert.That(() => Fibonacci.CalculateFibonacci(n), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        // Arrange
        int n = 0;
        int expected = 0;
        // Act

        int result = Fibonacci.CalculateFibonacci(n);

        // Assert
        Assert.That(result, Is.EqualTo(n));
    }

    [Test]
    public void Test_CalculateFibonacci_PositiveInput()
    {
        // Arrange
        int n = 4;
        int expected = 3;
        // Act

        int result = Fibonacci.CalculateFibonacci(n);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}