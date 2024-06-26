using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        //Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            { "orange", 3 },
            { "lemon", 12 },
            { "banana", 5 },
            { "cherry", 4 },
            { "pear", 11 },
            { "apple", 6 }

        };

        string fruit = "cherry";

        // Act
        int qty = Fruits.GetFruitQuantity(fruitDictionary, fruit);

        // Assert
        Assert.That(qty, Is.EqualTo(4));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            { "orange", 3 },
            { "lemon", 12 },
            { "banana", 5 },
            { "cherry", 4 },
            { "pear", 11 },
            { "apple", 6 }

        };

        string fruit = "strawberry";

        // Act
        int qty = Fruits.GetFruitQuantity(fruitDictionary, fruit);

        // Assert
        Assert.That(qty, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>();
        

        string fruit = "cherry";

        // Act
        int qty = Fruits.GetFruitQuantity(fruitDictionary, fruit);

        // Assert
        Assert.That(qty, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = null;


        string fruit = "cherry";

        // Act
        int qty = Fruits.GetFruitQuantity(fruitDictionary, fruit);

        // Assert
        Assert.That(qty, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            { "orange", 3 },
            { "lemon", 12 },
            { "banana", 5 },
            { "cherry", 4 },
            { "pear", 11 },
            { "apple", 6 }

        };


        string fruit = null;

        // Act
        int qty = Fruits.GetFruitQuantity(fruitDictionary, fruit);

        // Assert
        Assert.That(qty, Is.EqualTo(0));
    }
}
