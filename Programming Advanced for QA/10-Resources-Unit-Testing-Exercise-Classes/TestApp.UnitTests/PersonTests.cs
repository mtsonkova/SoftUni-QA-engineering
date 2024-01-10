using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]
    public void SetUp()
    {
        _person = new Person();
    }

    // TODO: finish test
    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        List<Person> expectedPeopleList = new List<Person>();

        for (int i = 0; i < peopleData.Length; i++)
        {
            string[] peopleInfo = peopleData[i].Split(" ");
            string name = peopleInfo[0];
            string id = peopleInfo[1];
            int age = int.Parse(peopleInfo[2]);

            Person currentPerson = expectedPeopleList.Find(people => people.Id == id);
            if (currentPerson is null)
            {
                expectedPeopleList.Add(new()
                {
                    Name = name,
                    Id = id,
                    Age = age

                });

            }
            else
            {
                currentPerson.Age = age;
                currentPerson.Name = name;
            }
        }

        // Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));
        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        string expectedSortedPeopleByAge = $"Bob with ID: B002 is 30 years old.{Environment.NewLine}Alice with ID: A001 is 35 years old.";
       
        // Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);
        String actualSortedPeopleByAge = this._person.GetByAgeAscending(resultPeopleList);

        // Assert
        Assert.That(actualSortedPeopleByAge, Is.EqualTo(expectedSortedPeopleByAge));
       
    }
}
