namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> inventory = new Dictionary<string, List<double>>();
            string input = Console.ReadLine();

            while(input != "buy")
            {
                string[] inputSplitted = input.Split(" ");
                string name = inputSplitted[0];
                double price = double.Parse(inputSplitted[1]);
                double qty = double.Parse(inputSplitted[2]);
                List<double> productInfo = new List<double> { price, qty };

                if(inventory.ContainsKey(name))
                {
                    inventory[name][0] = price;
                    inventory[name][1] += qty;
                }
                else
                {
                    inventory[name] = productInfo;
                }

                input = Console.ReadLine();
            }

            foreach(KeyValuePair<string, List<double>> item in inventory)
            {
                double finalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {finalPrice:F2}");
            }
        }

    }
}