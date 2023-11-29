using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string text = "This is a valid text";
        // Act
        string expected = "txet dilav a si sihT";
        string result = this._exceptions.ArgumentNullReverse(text);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        //Arrange
        decimal totalPrice = 200m;
        decimal discount = 5m;
        decimal expectedPrice = 190m;
        //Act
        decimal actualPrice = this._exceptions.ArgumentCalculateDiscount(totalPrice, discount);
        //Assert
        Assert.That(actualPrice, Is.EqualTo(expectedPrice));


    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 200m;
        decimal discount = -5m;
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }


    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        //Arrange
        int[] array = new int[] { 2, 4, 6, 8, 1, 0, 12, 75, 3, 62 };
        int index = 2;
        int expected = 6;

        //Act
        int result = this._exceptions.IndexOutOfRangeGetElement(array, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = new int[] { 2, 4, 6, 8, 1, 0, 12, 75, 3, 62 };
        int index = -2;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.Throws<System.IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(array, index));
    }
    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {

        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length + 5;

        // Act & Assert
        Assert.Throws<System.IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(array, index));
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool isLoggedIn = true;
        string expected = "User logged in.";

        // Act 
        string result = this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        bool isLoggedIn = false;
        //string expected = "User must be logged in to perform this operation.";

        //Act & Assert
        Assert.Throws<System.InvalidOperationException>(() => this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn));
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        //Arrange
        string input = "145";
        int expected = 145;

        // Act
        int actual = this._exceptions.FormatExceptionParseInt(input);

        //Assert
        Assert.That(actual, Is.EqualTo(expected));

    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        //Arrange
        string input = "text";


        // Act & Assert

        //Assert
        Assert.Throws<System.FormatException>(() => this._exceptions.FormatExceptionParseInt(input)); ;
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> phonebook = new Dictionary<string, int> {
            { "Lora", 0785623456 },
            { "Simeon" , 0921341235 },
            { "Ivan", 0888345234 }
        };

        string key = "Lora";

        int expected = 0785623456;

        // Act
        int actual = this._exceptions.KeyNotFoundFindValueByKey(phonebook, key);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }


    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> phonebook = new Dictionary<string, int> {
            { "Lora", 0785623456 },
            { "Simeon" , 0921341235 },
            { "Ivan", 0888345234 }
        };

        string key = "Pesho";

        //Act and Assert
        Assert.Throws<KeyNotFoundException>(() => this._exceptions.KeyNotFoundFindValueByKey(phonebook, key));
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Act & Assert
        Assert.That(this._exceptions.OverflowAddNumbers(2, 3), Is.EqualTo(5));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = int.MaxValue;
        int b = 5;

        //Act & Assert
        Assert.Throws<OverflowException>(() => this._exceptions.OverflowAddNumbers(a, b));
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = -6;
        int b = int.MinValue;

        //Act & Assert
        Assert.Throws<OverflowException>(() => this._exceptions.OverflowAddNumbers(a, b));
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int dividend = 10;
        int divisor = 5;
        int expected = 2;

        // Act
        int actual = this._exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int dividend = 10;
        int divisor = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => this._exceptions.DivideByZeroDivideNumbers(dividend, divisor));
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] collection = new int[] { 2, 4, 5, 7, 12, 3 };
        int index = 2;
        int expectedSum = 33;

        // Act
        int actualSum = this._exceptions.SumCollectionElements(collection, index);

        // Assert
        Assert.That(expectedSum, Is.EqualTo(actualSum));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] collection = null;
        int index = 2;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => this._exceptions.SumCollectionElements(collection, index));
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] collection = new int[] { 2, 4, 5, 7, 12, 3 };
        int index = collection.Length + 2;
        // Act

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            this._exceptions.SumCollectionElements(collection, index);
        }, "Index has to be within bounds.");
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {

        // Arrange
        Dictionary<string, string> studentsGrades = new Dictionary<string, string> {
            { "Lora", "6" },
            { "Simeon" , "5"},
            { "Ivan", "3" }
        };

        string key = "Lora";
        int expected = 6;

        // Act
        int actual = this._exceptions.GetElementAsNumber(studentsGrades, key);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> studentsGrades = new Dictionary<string, string> {
            { "Lora", "6" },
            { "Simeon" , "5"},
            { "Ivan", "3" }
        };

        string key = "Sasho";
       

        // Act & Assert 
        Assert.Throws<KeyNotFoundException>(() => this._exceptions.GetElementAsNumber(studentsGrades, key));
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> studentsGrades = new Dictionary<string, string> {
            { "Lora", "6" },
            { "Simeon" , "5.75"},
            { "Ivan", "3" }
        };

        string key = "Simeon";


        // Act & Assert 
        Assert.Throws<FormatException>(() => this._exceptions.GetElementAsNumber(studentsGrades, key));
    }
}
