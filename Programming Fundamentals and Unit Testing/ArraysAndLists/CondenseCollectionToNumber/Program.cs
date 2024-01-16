using System.Diagnostics.CodeAnalysis;

namespace CondenseCollectionToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            while(nums.Count > 2)
            {
                for(int i = 0; i < nums.Count - 2; i++)
                {
                    
                        nums[i] += nums[i + 1];
                        nums[i + 2] += nums[i + 1];
                        nums.Remove(nums[i + 1]);
                    
                }
            }

            Console.WriteLine(nums.Count);
            Console.WriteLine(nums[1]);

        }
    }
}
