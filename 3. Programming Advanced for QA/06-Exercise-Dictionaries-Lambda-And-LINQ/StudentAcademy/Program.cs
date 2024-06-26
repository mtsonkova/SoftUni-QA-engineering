namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            string name = "";

            for (int i = 1; i <= n * 2; i++)
            {
               
                if(i % 2 != 0)
                {
                    name = Console.ReadLine();
                    if(students.ContainsKey(name) == false)
                    {
                        students[name] = new List<double>();
                    }
                
                } else if(i % 2 == 0)
                {
                    double grade = double.Parse(Console.ReadLine());
                    students[name].Add(grade);
                } 
            }

            foreach(KeyValuePair<string, List<double>> student in students)
            {
                double averageGrade = student.Value.Average();
                if(averageGrade >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:F2}");
                }
            }
        }
    }
}