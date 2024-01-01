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
        _toDoList.AddTask("Solve problem 1", DateTime.Now);
        string toDoList = this._toDoList.DisplayTasks();
        bool hasTask = toDoList.Contains("Wash the dishes");
        Assert.IsTrue(hasTask);
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        DateTime dueDate = new DateTime(2024, 5, 1);
        this._toDoList.AddTask("Watch a movie", DateTime.Now);
        this._toDoList.AddTask("Solve problem 2", dueDate);

        this._toDoList.CompleteTask("Solve problem 2");
        String allTasks = this._toDoList.DisplayTasks();
        Assert.That(allTasks.Contains("Watch a movie - Due: 01/01/2024\r\n[✓]"));


    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        //Arrange Act and Assert
        Assert.Throws<ArgumentException>(() => this._toDoList.CompleteTask("Watch lection 1"));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        //Arrange Act and Assert
        Assert.That(this._toDoList.DisplayTasks(), Is.EqualTo("To-Do List:"));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // TODO: finish the test
    }
}
