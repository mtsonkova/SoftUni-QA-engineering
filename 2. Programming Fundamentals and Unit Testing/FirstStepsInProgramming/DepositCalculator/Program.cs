namespace DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //formula amount = deposited amount + term of deposit * (deposited amount * annual interest rate) / 12

            double depositedAmount = double.Parse(Console.ReadLine());
            int termOfDeposit = int.Parse(Console.ReadLine());
            double anualInterestRate = double.Parse(Console.ReadLine());

            double amount = depositedAmount + termOfDeposit * (depositedAmount * (anualInterestRate * 0.01 / 12));
            Console.WriteLine(amount);

        }
    }
}