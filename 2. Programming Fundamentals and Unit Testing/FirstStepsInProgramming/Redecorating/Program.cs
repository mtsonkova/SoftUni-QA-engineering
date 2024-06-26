namespace Redecorating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nylonPrice = 1.50;
            double paintPrice = 14.50;
            double paintThinenrPrice = 5.00;

            int nylon = int.Parse(Console.ReadLine()) + 2;
            int paint = int.Parse(Console.ReadLine());
            int paintThinner = int.Parse(Console.ReadLine());
            int cradtsmanWorkHours = int.Parse(Console.ReadLine());
            double nylonBags = 0.4;
          
            double materialsCosts = (nylon * nylonPrice) + (paintPrice * (paint + paint * 0.1)) +
                (paintThinenrPrice * paintThinner) + nylonBags;
            
            double craftsmanPrice = (materialsCosts * 0.3) * cradtsmanWorkHours;
            double totalPrice = materialsCosts + craftsmanPrice;

            Console.WriteLine(totalPrice);



        }
    }
}