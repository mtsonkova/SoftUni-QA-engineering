using GardenConsoleAPI.Business;
using GardenConsoleAPI.Business.Contracts;
using GardenConsoleAPI.Data.Models;
using GardenConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace GardenConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestPlantsDbContext dbContext;
        private IPlantsManager plantsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestPlantsDbContext();
            this.plantsManager = new PlantsManager(new PlantsRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddPlantAsync_ShouldAddNewPlant()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "123456789101",
                Name = "tomato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            // Act
            await this.plantsManager.AddAsync(newPlant);

            // find newly added plant in db
            var dbPlant = await dbContext.Plants.FirstOrDefaultAsync(p => p.Name == newPlant.Name);
            // Assert
            Assert.NotNull(dbPlant);
        }

        //Negative test
        [Test]
        public async Task AddPlantAsync_TryToAddPlantWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
           
            var newPlant = new Plant()
            {
                Name = "",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

           // Act & Assert
            Assert.ThrowsAsync<ValidationException>(() => this.plantsManager.AddAsync(newPlant));                  

        }

        [Test]
        public async Task DeletePlantAsync_WithValidCatalogNumber_ShouldRemovePlantFromDb()
        {
            // Arrange
           var newPlant = new Plant()
            {
                CatalogNumber = "123456789101",
                Name = "tomato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant);
            // Act

            await this.plantsManager.DeleteAsync(newPlant.CatalogNumber);
            var deletedPlantFromDb = await dbContext.Plants.FirstOrDefaultAsync(p => p.CatalogNumber == newPlant.CatalogNumber);

            // Assert
            Assert.Null(deletedPlantFromDb);
        }

        [Test]
        public async Task DeletePlantAsync_TryToDeleteWithNullOrWhiteSpaceCatalogNumber_ShouldThrowException()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "123456789101",
                Name = "tomato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant);
            // Act && Assert

            Assert.ThrowsAsync<ArgumentException>(() => this.plantsManager.DeleteAsync(null));        
        }

        [Test]
        public async Task GetAllAsync_WhenPlantsExist_ShouldReturnAllPlants()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "123456789101",
                Name = "tomato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant);

            var newPlant2 = new Plant()
            {
                CatalogNumber = "123456789104",
                Name = "potato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant2);

            // Act
            var allPlants = await this.plantsManager.GetAllAsync();

            // Assert
            Assert.NotNull(allPlants);
            Assert.That(allPlants.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllAsync_WhenNoPlantsExist_ShouldThrowKeyNotFoundException()
        {
            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => this.plantsManager.GetAllAsync());
        }

        [Test]
        public async Task SearchByFoodTypeAsync_WithExistingFoodType_ShouldReturnMatchingPlants()
        {
            var newPlant = new Plant()
            {
                CatalogNumber = "123456789101",
                Name = "tomato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant);

            var newPlant2 = new Plant()
            {
                CatalogNumber = "123456789141",
                Name = "peach",
                PlantType = "fruit",
                FoodType = "minerals",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant2);

            // Act
            var plantByFoodType = await this.plantsManager.SearchByFoodTypeAsync(newPlant2.FoodType);
            
            // Assert
            Assert.NotNull(plantByFoodType);
        }

        [Test]
        public async Task SearchByFoodTypeAsync_WithNonExistingFoodType_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "123456789101",
                Name = "tomato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant);

            var newPlant2 = new Plant()
            {
                CatalogNumber = "123456789141",
                Name = "peach",
                PlantType = "fruit",
                FoodType = "minerals",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant2);

            // Act && Assert
            Assert.ThrowsAsync<ArgumentException>(() => this.plantsManager.SearchByFoodTypeAsync(""));           
           
        }

        [Test]
        public async Task GetSpecificAsync_WithValidCatalogNumber_ShouldReturnPlant()
        {
            // Arrange
            var newPlant = new Plant()
            {
                CatalogNumber = "123456789101",
                Name = "tomato",
                PlantType = "vegetable",
                FoodType = "soil",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant);

            var newPlant2 = new Plant()
            {
                CatalogNumber = "123456789141",
                Name = "peach",
                PlantType = "fruit",
                FoodType = "minerals",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant2);

            // Act
            var plantInDB = await this.plantsManager.GetSpecificAsync(newPlant2.CatalogNumber);
            
            // Assert
            Assert.NotNull(plantInDB);
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidCatalogNumber_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            var newPlant2 = new Plant()
            {
                CatalogNumber = "123456789141",
                Name = "peach",
                PlantType = "fruit",
                FoodType = "minerals",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant2);

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => this.plantsManager.GetSpecificAsync("2"));
        }

        [Test]
        public async Task UpdateAsync_WithValidPlant_ShouldUpdatePlant()
        {
            // Arrange
            var newPlant2 = new Plant()
            {
                CatalogNumber = "123456789141",
                Name = "peach",
                PlantType = "fruit",
                FoodType = "minerals",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant2);

            newPlant2.FoodType = "minerals, soil and water";
            newPlant2.Quantity = 20;
            
            // Act
            await this.plantsManager.UpdateAsync(newPlant2);

            var updatedPlantFromDb = await dbContext.Plants.FirstOrDefaultAsync(p => p.CatalogNumber == newPlant2.CatalogNumber);
            // Assert
            Assert.That(updatedPlantFromDb.Quantity, Is.EqualTo(20));
            Assert.That(updatedPlantFromDb.FoodType, Is.EqualTo("minerals, soil and water"));
        }

        [Test]
        public async Task UpdateAsync_WithInvalidPlant_ShouldThrowValidationException()
        {
            // Arrange
            var newPlant2 = new Plant()
            {
                CatalogNumber = "123456789141",
                Name = "peach",
                PlantType = "fruit",
                FoodType = "minerals",
                Quantity = 10
            };

            var newPlant3 = new Plant()
            {
                CatalogNumber = "12345678g141",
                Name = "cherry",
                PlantType = "fruit",
                FoodType = "minerals",
                Quantity = 10
            };

            await this.plantsManager.AddAsync(newPlant2);

            // Act && Assert
            Assert.ThrowsAsync<ValidationException>(async () => await this.plantsManager.UpdateAsync(newPlant3));
        }
    }
}
