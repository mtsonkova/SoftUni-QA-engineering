namespace MagicNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int product = 0;
            List<int> magicNumbers = new List<int>();

           for(int i = 1; i <= 9; i++)
            {               
               for(int j = 1; j <= 9; j++)
                {               
                  for(int k = 1; k <= 9; k++)
                    {
                        product = i * j * k;
                       
                        if(product == n)
                        {
                            string concat = $"{i}{j}{k}";
                            int magicNum = int.Parse(concat);
                            magicNumbers.Add(magicNum);
                        }
                    }
                } 
            }

            Console.WriteLine(String.Join(" ", magicNumbers));
        }
    }
}
