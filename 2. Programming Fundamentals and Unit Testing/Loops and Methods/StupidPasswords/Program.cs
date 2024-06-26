using System.ComponentModel;

namespace StupidPasswords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int firstDigit = 0;
            int secondDigit = 0;
            int thirdDigit = 0;
            string pass = "";
            List<string> stupidPasswords = new List<string>();
            
            for(int i = 2; i <= num; i+=2)
            {
                firstDigit = i;

                for (int j = 1; j <= num; j += 2)
                {
                    secondDigit = j;
                    thirdDigit = i * j;

                    pass = $"{firstDigit}{secondDigit}{thirdDigit}";
                    stupidPasswords.Add(pass);
                }
            }

            Console.WriteLine(String.Join(' ', stupidPasswords));
        }
    }
}
