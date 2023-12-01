using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        private string firstName { get; set; }
        private string lastName { get; set; }
        private double grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
        }

        public string FirstName { get { return firstName; } set {  firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public double Grade { get { return grade; } set { grade = value; } }
    }
}
