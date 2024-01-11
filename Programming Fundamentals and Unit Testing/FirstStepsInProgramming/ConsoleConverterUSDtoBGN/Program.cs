using System.Transactions;

namespace ConsoleConverterUSDtoBGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double conversionRate = 1.79549;
            double leva = usd * conversionRate;
            Console.WriteLine(leva);
        }
    }
}