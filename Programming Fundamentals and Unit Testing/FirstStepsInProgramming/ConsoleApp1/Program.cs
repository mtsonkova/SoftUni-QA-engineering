using System.Runtime.ConstrainedExecution;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pensPrice = 5.80;
            double markersPrice = 7.20;
            double boardCleanerPrice = 1.20;

            int pensQty = int.Parse(Console.ReadLine());
            int markersQty = int.Parse(Console.ReadLine());
            int boardCleanerQty = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double totalPrice = (pensPrice * pensQty + markersPrice * markersQty + 
                boardCleanerPrice * boardCleanerQty) * (1 - discount * 0.01);
            Console.WriteLine(totalPrice);


        }
    }
}