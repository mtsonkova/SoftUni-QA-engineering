using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    // TODO: finish the test
    [TestCase("testmail@qa.test")]
    [TestCase("iamvalid@com.qa")]
    [TestCase("softuni@gmail.com")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    // TODO: finish the test
    [TestCase(".com")]
    [TestCase("testcase")]
    [TestCase("test@case")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
