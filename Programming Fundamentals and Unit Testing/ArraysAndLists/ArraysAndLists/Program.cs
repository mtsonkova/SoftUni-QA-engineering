using System.Linq;

namespace ArraysAndLists
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine().Split(" ").Select(num => int.Parse(num)).ToArray();

            List<int> topInts = new List<int>();
            bool isBigger = false;
            int currentNum = 0;
            int lastBiggestNum = 0;
           
            for(int i = 0; i <  nums.Length - 1; i++)
            {
                int numI = nums[i];
               for( int j = 1; j < nums.Length; j++)
                {
                    int numj = nums[j];
                    
                    if (numj >= numI && numj > lastBiggestNum)
                    {
                        isBigger = true;
                        currentNum = numj;

                        if (isBigger && topInts.Contains(currentNum) == false)
                        {
                            topInts.Add(currentNum);
                            lastBiggestNum = currentNum;
                        }
                    }

                    
                }

                

            }           

            Console.WriteLine(String.Join(" ", topInts));
        }

       
    }
}