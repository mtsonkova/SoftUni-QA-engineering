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
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int studentsCount = int.Parse(Console.ReadLine());

            for(int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ").ToArray();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);

                Student student = new Student(firstName, lastName, grade);
                
                students.Add(student);
                
            }

           var sortedList = students.OrderByDescending(student => student.grade);
            foreach(Student student in sortedList)
            {
                Console.WriteLine($"{student.firstName} {student.lastName} {student.grade}");
            }

        }
    }
}