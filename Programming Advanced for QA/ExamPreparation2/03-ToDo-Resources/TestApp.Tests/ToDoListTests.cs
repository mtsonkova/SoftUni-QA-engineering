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
        DateTime dueDate1 = new DateTime(2024, 1, 1);
        DateTime dueDate2 = new DateTime(2024, 1, 9);
        DateTime dueDate3 = new DateTime(2024, 1, 3);
        this._toDoList.AddTask("Watch a movie", dueDate1);
        this._toDoList.AddTask("Solve problem 2", dueDate2);
        this._toDoList.AddTask("Watch lection 4", dueDate3);
       
        this._toDoList.CompleteTask("Solve problem 2");
        String expected = "To-Do List:"+ Environment.NewLine + "[ ] Watch a movie - Due: 01/01/2024" + Environment.NewLine
            + "[✓] Solve problem 2 - Due: 01/09/2024" + Environment.NewLine + "[ ] Watch lection 4 - Due: 01/03/2024";
        String actual = this._toDoList.DisplayTasks();
        Assert.That(actual, Is.EqualTo(expected));
    }
}
