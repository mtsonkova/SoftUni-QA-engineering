using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public double grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
        }

        public override string ToString()
        {
            return $"{this.firstName} - {this.lastName}: {this.grade}".Trim();
        }
    }
}
