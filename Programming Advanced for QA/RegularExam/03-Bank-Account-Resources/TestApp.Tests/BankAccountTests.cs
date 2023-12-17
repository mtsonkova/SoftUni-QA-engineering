using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(2000.0);

        //Assert
        Assert.That(bankAccount, Is.Not.Null);
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(2000.00);

        // Act
        bankAccount.Deposit(245.33);

        // Assert
        Assert.That(bankAccount.Balance, Is.EqualTo(2245.33));       
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(1500.57);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => bankAccount.Deposit(-234.56));

    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(1500.57);

        // Act
        bankAccount.Withdraw(500.57);
        //Assert
        Assert.That(bankAccount.Balance, Is.EqualTo(1000));
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(1500.57);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => bankAccount.Withdraw(-234.56));
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(1500.57);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => bankAccount.Withdraw(5000.56));
    }
}
