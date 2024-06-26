using Xunit.Sdk;

namespace TownApplication.IntegrationTests
{
    public class TownControllerIntegrationTests
    {
        private readonly TownController _controller;

        public TownControllerIntegrationTests()
        {
            _controller = new TownController();
            _controller.ResetDatabase();
        }

        [Fact]
        public void AddTown_ValidInput_ShouldAddTown()
        {
            // TODO: This test checks if the AddTown method correctly adds a town with valid inputs.

            // Arrange: Prepare the data for the test.
            // 1. Define a town name that is valid (e.g., not too long, not empty).
            // 2. Define a valid population number (positive integer).
            // Replace the placeholder values with actual valid data.
            // Ensure the name is within the valid length

            // Arrange
            string townName = "Sofia";
            int population = 2000000;

            // Act: Perform the action to be tested.
            // Call the AddTown method on the _controller with the arranged data.
            // Act

            this._controller.AddTown(townName, population);
            var towns = this._controller.ListTowns();
            // Assert: Verify the outcome of the action.

            // Assert
            Assert.True(towns.Count > 0);
            Assert.Equal(towns.First().Name, townName);
            Assert.Equal(towns[0].Population, population);
            // 1. Check if the town was actually added to the database.
            // 2. Verify that the town's data in the database matches the data provided.
            // Use Assert.NotNull to ensure the town is found in the database.
            // Use Assert.Equal to compare the expected and actual population values.
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("AB")]
        public void AddTown_InvalidName_ShouldThrowArgumentException(string invalidName)
        {
            // TODO: This test verifies that the AddTown method throws an ArgumentException for invalid names.

            // Arrange: Set up the test data.
            // 1. The 'invalidName' parameter is provided by the InlineData attributes.
            // 2. Define a population number that is valid (e.g., positive integer).
            // Replace the placeholder value with actual valid data.

            // Arrange
            int population = 2000000;
            string expectedExceptionMsg = "Invalid town name.";

            // Act & Assert: Execute the test and check for expected outcomes.
            // 1. Call the AddTown method with the invalid name and check that it throws an ArgumentException.
            // 2. Verify that the exception message is as expected.

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => this._controller.AddTown(invalidName, population));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddTown_InvalidPopulation_ShouldThrowArgumentException(int invalidPopulation)
        {
            // TODO: This test ensures that the AddTown method correctly handles invalid population values.

            // Arrange: Prepare the test data.
            // 1. Define a valid town name.
            // 2. The 'invalidPopulation' parameter is provided by the InlineData attributes.
            // Replace the placeholder value with actual valid data.

            // Arrange
            string townName = "New York";
            string expectedErrMsg = "Population must be a positive number.";
            // Act: Execute the action to be tested.

            Action addAction = () => this._controller.AddTown(townName, invalidPopulation);
            
            // Wrap the call to AddTown in an Action delegate to use with Assert.Throws.
            var exception = Assert.Throws<ArgumentException>(addAction);
            Assert.Equal(expectedErrMsg, exception.Message);
            // Assert: Verify the outcome of the action.
            // Check if an ArgumentException is thrown and validate the exception message.
        }

        [Fact]
        public void AddTown_DuplicateTownName_DoesNotAddDuplicateTown()
        {
            // TODO: This test verifies that the AddTown method does not add a duplicate town.

            // Arrange: Set up the test data.
            // 1. Define a town name to use for testing.
            // 2. Define a population number for the town.
            // Use the same name for both additions to simulate a duplicate entry.
            // Arrange

            string townName = "Sofia";
            int population = 3000000;

            // Add a town initially to set up the duplicate scenario.
            // Act
         
            this._controller.AddTown(townName, population);
            this._controller.AddTown(townName, population);
           var towns = this._controller.ListTowns();

            //Assert
            Assert.True(towns.Count == 1);
            Assert.True(towns[0].Name == townName);
            Assert.True(towns[0].Population == population);
            // Act: Try to add the same town again.

            // Assert: Verify that a duplicate town was not added.
            // 1. Check the total number of towns in the database.
            
            // 2. Ensure that the count is still 1, indicating no duplicate was added.
        }

        [Fact]
        public void UpdateTown_ShouldUpdatePopulation()
        {
            //Arrange
            string townName = "Sofia";
            int population = 1000000;
            int newPopulation = 3000000;

            //Act
            this._controller.AddTown(townName, population);
            this._controller.UpdateTown(1, newPopulation);
            var towns = this._controller.ListTowns();

            //Assert
            Assert.Equal(towns[0].Population, newPopulation);
        }

        [Fact]
        public void DeleteTown_ShouldDeleteTown()
        {
            // TODO: This test ensures that the DeleteTown method correctly removes a town from the database.

            // Arrange: Prepare the data and initial state for the test.
            // 1. Define a town name and population number.
            // 2. Add the town to the database to set up the deletion scenario.
            //Arrange
            string townName = "Sofia";
            int population = 3000000;
            this._controller.AddTown(townName, population);

            // Act
            this._controller.DeleteTown(1);

            // Act: Perform the deletion action.
            // 1. Retrieve the town to be deleted.
            // 2. Call the DeleteTown method with the town's ID

            //Assert
            // Assert: Verify that the town was successfully deleted.
            // 1. Attempt to retrieve the deleted town and check that it no longer exists in the database.
            // 2. Use Assert.Null to ensure that the town is not found.
            Assert.Null(this._controller.GetTownByName(townName));
        }

        [Fact]
        public void ListTowns_ShouldReturnTowns()
        {
            // TODO: This test checks if the ListTowns method correctly returns a list of all towns in the database.

            // Arrange: Prepare the data for the test.
            // 1. Add several towns to the database to create a list of towns.
            // Each town should have a unique name and a valid population number.
            string firstTownName = "Sofia";
            int firstTownPopulation = 3000000;
            string secondTownName = "Plovdiv";
            int secondTownPopulation = 1000000;

            this._controller.AddTown(firstTownName, firstTownPopulation);
            this._controller.AddTown(secondTownName, secondTownPopulation);

            // Act

            var towns = this._controller.ListTowns();
            //Assert
            Assert.True(towns.Count == 2);
            Assert.True(towns[0].Name == firstTownName);
            Assert.True(towns[1].Name == secondTownName);
            // Assert: Verify the correctness of the retrieved list.
            // 1. Check if the number of towns in the list matches the number of towns added.
            // 2. Verify that each added town is present in the list.
        }
    }
}
