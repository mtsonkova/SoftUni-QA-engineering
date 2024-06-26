namespace HappyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<String> happyNums = new List<String>();

            for(int firstNum = 1; firstNum <=  n; firstNum++)
            {
                for(int secondNum = 0; secondNum <= n; secondNum++)
                {
                    for(int thirdNum = 0; thirdNum <= n; thirdNum++)
                    {
                        for(int fourthNum = 0; fourthNum <= n; fourthNum++)
                        {
                            if((firstNum + secondNum) == (thirdNum + fourthNum) && (firstNum + secondNum) == n)
                            {
                                string happyNum = $"{firstNum}{secondNum}{thirdNum}{fourthNum}";
                                happyNums.Add(happyNum);
                            }
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", happyNums));
        }
    }
}
