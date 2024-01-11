namespace BasketballEquiment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int trainingFee = int.Parse(Console.ReadLine());

            double sneakersPrice = trainingFee * 0.6;
            double teamPrice = sneakersPrice * 0.8;
            double basketballPrice = teamPrice * 0.25;
            double accessoriesPrice = basketballPrice * 0.2;

            double totalPrice = trainingFee + sneakersPrice + teamPrice + basketballPrice + accessoriesPrice;
            Console.WriteLine(totalPrice);
        }
    }
}