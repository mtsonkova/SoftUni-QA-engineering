using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act 
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = { "apple 5.97 1", "banana 3.75 1", "orange 1.98 1" };

        // Act
       string result = Orders.Order(input);

        // Assert
       Assert.That(result, Is.EqualTo($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98"));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = { "apple 5.971 2", "banana 3.753 3", "orange 1.982 2" };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 11.94{Environment.NewLine}banana -> 11.26{Environment.NewLine}orange -> 3.96"));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = { "apple 5.971 2.5", "banana 3.753 3.8", "orange 1.982 2.4" };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 14.93{Environment.NewLine}banana -> 14.26{Environment.NewLine}orange -> 4.76"));
    }
}
