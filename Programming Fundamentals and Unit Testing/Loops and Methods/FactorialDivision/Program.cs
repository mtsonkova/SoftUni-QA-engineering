namespace FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int firstFactorial = CalculateFactorial(firstNum);
            int secondFactorial = CalculateFactorial(secondNum);
            int factorialDivision = firstFactorial / secondFactorial;

            Console.WriteLine(factorialDivision);
        }

        public static int CalculateFactorial(int firstNum)
        {
            int factorial = 1;
            for (int i = 1; i <= firstNum; i++)
            {
                factorial *= i;

            }
            return factorial;
        }
    }
}

