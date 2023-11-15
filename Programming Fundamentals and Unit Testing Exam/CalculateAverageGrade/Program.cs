namespace CalculateAverageGrade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsNum = int.Parse(Console.ReadLine());

            double sum = 0;
            double averageGrade = 0;

            for (int i = 0; i < studentsNum; i++)
            {
                double currentGrade = double.Parse(Console.ReadLine());
                sum += currentGrade;
            }

            averageGrade = sum / studentsNum;

            Console.WriteLine($"{averageGrade:F2}");
        }
    }
}