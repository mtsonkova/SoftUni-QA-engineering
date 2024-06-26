using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = Array.Empty<string>(); 
        
        // Act
        string result = Plants.GetFastestGrowing(plants);
        
        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = { "rose" };
        string expected = "Plants with 4 letters:\r\nrose";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result,Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = { "rose", "lettice", "grapes" };
        string expected = "Plants with 4 letters:\r\nrose\r\nPlants with 6 letters:\r\ngrapes\r\nPlants with 7 letters:\r\nlettice";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] plants = { "rosE", "LeTtIcE", "GrapeS" };
        string expected = "Plants with 4 letters:\r\nrosE\r\nPlants with 6 letters:\r\nGrapeS\r\nPlants with 7 letters:\r\nLeTtIcE";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
