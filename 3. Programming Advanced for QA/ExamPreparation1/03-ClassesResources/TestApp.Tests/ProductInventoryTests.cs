using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
      
        _inventory.AddProduct("Cola", 3.40, 2);
        Assert.That(_inventory.DisplayInventory().Contains("Cola"));
    
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        string expected = "Product Inventory:";
        Assert.That(_inventory.DisplayInventory, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        _inventory.AddProduct("Cola", 3.40, 2);
        string expected = "Product Inventory:\r\nCola - Price: $3.40 - Quantity: 2";
        string actual = _inventory.DisplayInventory();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        double totalValue = _inventory.CalculateTotalValue();
        Assert.That(totalValue, Is.Zero);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        _inventory.AddProduct("Cola", 3.40, 2);
        _inventory.AddProduct("Fanta", 2.50, 5);
        double expectedTotalValue = 19.30;
        double actualTotalValue = _inventory.CalculateTotalValue();

        Assert.That(actualTotalValue, Is.EqualTo(expectedTotalValue));
    }
}
