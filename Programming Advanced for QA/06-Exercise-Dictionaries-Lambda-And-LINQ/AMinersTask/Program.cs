using System.Diagnostics.Metrics;

namespace AMinersTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> inventory = new Dictionary<string, int>();
            int counter = 0;
            string resource = String.Empty;
            int qty = 0;
            while(input !="stop")
            {
                counter++;
                if(counter %2 != 0)
                {
                    resource = input;

                    if(inventory.ContainsKey(input)== false)
                    {
                        inventory[input] = 0;
                    }
                } else if(counter % 2 == 0)
                {
                    inventory[resource] += int.Parse(input);
                }

                input = Console.ReadLine();
                
            }

            foreach (KeyValuePair<string, int> element in inventory)
            {
                Console.WriteLine($"{element.Key} -> {element.Value}");
            }
        }
    }
}