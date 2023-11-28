using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class BalancedBracketsTests
{
    string[] brackets = null;
    bool result = true;

    [Test]
    public void Test_IsBalanced_EmptyInput_ShouldReturnTrue()
    {
        // arrange
        brackets = new string[] {""};

        // act
        result = BalancedBrackets.IsBalanced(brackets);
        
        // assert

        Assert.That(result, Is.True);
    }

    [Test]
    public void Test_IsBalanced_BalancedBrackets_ShouldReturnTrue()
    {
        // arrange
        brackets = new string[] { "(", ")", "(", ")" };

        // act
        result = BalancedBrackets.IsBalanced(brackets);

        // assert

        Assert.That(result, Is.True);
    }

    [Test]
    public void Test_IsBalanced_UnbalancedBrackets_ShouldReturnFalse()
    {
        // arrange
        brackets = new string[] { ")", "(" };

        // act
        result = BalancedBrackets.IsBalanced(brackets);

        // assert

        Assert.That(result, Is.False);
    }

    [Test]
    public void Test_IsBalanced_MoreClosingBrackets_ShouldReturnFalse()
    {
        // arrange
        brackets = new string[] { "(", ")", ")",")" };

        // act
        result = BalancedBrackets.IsBalanced(brackets);

        // assert

        Assert.That(result, Is.False);
    }

    [Test]
    public void Test_IsBalanced_NoClosingBrackets_ShouldReturnFalse()
    {
        // arrange
        brackets = new string[] { "(", "(", "(", "(" };

        // act
        result = BalancedBrackets.IsBalanced(brackets);

        // assert

        Assert.That(result, Is.False);
    }
}
