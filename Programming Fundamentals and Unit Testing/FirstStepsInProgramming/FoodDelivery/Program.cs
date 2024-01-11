namespace FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double chickenMenu = 10.35;
            double fishMenu = 12.40;
            double vegetarianMenu = 8.15;
            double deliveryPrice = 2.5;

            int chickenMenuQty = int.Parse(Console.ReadLine());
            int fishMenuQty = int.Parse(Console.ReadLine());
            int vegetarianMenuQty = int.Parse(Console.ReadLine());

            double totalCostNoDesert = (chickenMenu * chickenMenuQty) + (fishMenu * fishMenuQty) +
                (vegetarianMenu * vegetarianMenuQty);
            double desertPrice = totalCostNoDesert * 0.2;

            double finalPrice = totalCostNoDesert + desertPrice + deliveryPrice;

            Console.WriteLine(finalPrice);

        }
    }
}