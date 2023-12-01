namespace Students
{
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

           var sortedList = students.OrderByDescending(student => student.Grade);
            foreach(Student student in sortedList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.Grade}");
            }

        }
    }
}