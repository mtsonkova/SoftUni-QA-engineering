using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        _toDoList.AddTask("Wash the dishes", DateTime.Now);
        string toDoList = _toDoList.DisplayTasks();
        bool hasTask = toDoList.Contains("Wash the dishes");
        Assert.IsTrue(hasTask);
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        _toDoList.CompleteTask("Wash the dishes");


    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // TODO: finish the test
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // TODO: finish the test
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // TODO: finish the test
    }
}
