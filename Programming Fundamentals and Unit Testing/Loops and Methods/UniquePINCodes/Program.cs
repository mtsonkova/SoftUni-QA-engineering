namespace UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int max1 = int.Parse(Console.ReadLine());
           int max2 = int.Parse(Console.ReadLine());
           int max3 = int.Parse(Console.ReadLine());

            int firstDigit = 0;
            int secondDigit = 0;
            int thirdDigit = 0;

            List<string> pincodes = new List<string>();

            for(int i = 2; i <= max1; i += 2)
            {
                firstDigit = i;
                for(int j = 2; j <= max2; j++)
                {
                    if(j == 2 || j == 3 || j == 5 || j == 7)
                    {
                        secondDigit = j;
                    }

                    for(int k = 2; k <= max3; k += 2)
                    {
                        thirdDigit = k;
                        string pincode = $"{firstDigit}{secondDigit}{thirdDigit}";

                        if(pincodes.Contains(pincode) == false)
                        {
                            pincodes.Add(pincode);
                        }
                    }
                }           
            }
            
            foreach(string pincode in pincodes)
            {
                Console.WriteLine(pincode);
            }
        }
    }
}
