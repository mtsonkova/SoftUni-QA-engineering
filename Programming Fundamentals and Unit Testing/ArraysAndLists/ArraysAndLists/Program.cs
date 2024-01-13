using System;
using System.ComponentModel.Design;
using System.Linq;

namespace ArraysAndLists
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine().Split(" ").Select(num => int.Parse(num)).ToArray();

            List<int> topInts = new List<int>();
            int biggestNum = 0;

            List<int> numbers = nums.ToList();
            while(numbers.Count > 0)
            {
                biggestNum = numbers.Max(num => num);
                if (topInts.Contains(biggestNum) == false)
                {
                    topInts.Add(biggestNum);
                }
                numbers.RemoveRange(0, numbers.IndexOf(biggestNum) + 1);
            }
            //topInts.Add(nums[nums.Length - 1]);

            Console.WriteLine(String.Join(" ", topInts));

        }

    }
}
