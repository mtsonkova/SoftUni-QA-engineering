namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingLot = new Dictionary<string, string>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string command = input[0];
                string name = input[1];
               

                switch(command)
                {
                    case ("register"):
                        {
                            string plateNumber = input[2];
                            registerUser(name, plateNumber, parkingLot);
                        }
                        break;

                    case ("unregister"):
                        {
                            unregisterUser(name, parkingLot);
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach(KeyValuePair<string, string>cars in  parkingLot)
            {
                Console.WriteLine($"{cars.Key} => {cars.Value}");
            }
        }

        //methods
        public static void registerUser(string name, string licensePlate, Dictionary<string, string>parlingLot)
        {
            if (parlingLot.ContainsKey(name))
            {
                Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
            } else
            {
                parlingLot[name] = licensePlate;
                Console.WriteLine($"{name} registered {licensePlate} successfully");
            }
        }

        public static void unregisterUser(string name, Dictionary<string, string> parlingLot)
        {
            if (parlingLot.ContainsKey(name))
            {
                parlingLot.Remove(name);
                Console.WriteLine($"{name} unregistered successfully");
            }
            else
            {
               Console.WriteLine($"ERROR: user {name} not found");
            }
        }


    }
}