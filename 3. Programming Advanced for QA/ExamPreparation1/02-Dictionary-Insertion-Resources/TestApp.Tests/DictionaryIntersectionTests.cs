using System.Collections.Generic;
using System.Reflection.Metadata;
using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{

    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int>();

        // Act & Assert

        Assert.That(DictionaryIntersection.Intersect(dict1, dict2), Is.Empty);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>
        {
            { "Maria",  6},
            {"Ivan", 5 },
            {"Simeon", 6 },
            {"Peter", 4 }
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>();

        // Act & Assert

        Assert.That(DictionaryIntersection.Intersect(dict1, dict2), Is.Empty);
    }


    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>
        {
            { "Maria",  6},
            {"Ivan", 5 },
            {"Simeon", 6 },
            {"Peter", 4 }
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>
        {
            {"Emilia", 4 },
            { "Svetla", 5 }
        };

        // Act & Assert

        Assert.That(DictionaryIntersection.Intersect(dict1, dict2), Is.Empty);
    }



    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        Dictionary<string, int> dict1 = new Dictionary<string, int>
        {
            { "Maria",  6},
            {"Ivan", 5 },
            {"Simeon", 6 },
            {"Peter", 4 }
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>
        {
            {"Emilia", 4 },
            { "Svetla", 5 },
            { "Maria",  6},
            {"Ivan", 5 }
        };

        Dictionary<string, int> expected = new Dictionary<string, int>
        {
            { "Maria",  6},
           { "Ivan", 5 }
        };

        //Act

        Dictionary<string, int> actual = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }


    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> dict1 = new Dictionary<string, int>
        {
            { "Maria",  3},
            {"Ivan", 2 },
            {"Simeon", 6 },
            {"Peter", 4 }
        };

        Dictionary<string, int> dict2 = new Dictionary<string, int>
        {
            {"Emilia", 4 },
            { "Svetla", 5 },
            { "Maria",  6},
            {"Ivan", 5 }
        };


        // Act & Assert
        Assert.That(DictionaryIntersection.Intersect(dict1, dict2), Is.Empty);
    }
}
