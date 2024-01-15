namespace SumAdjastentEqualNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            bool hasAdjustentEqualNums = true;

            while (HasAdjacentEqualNums(nums))
            {
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    int firstNum = nums[i];
                    int secondNum = nums[i + 1];
                    if (firstNum == secondNum)
                    {
                        firstNum += secondNum;
                        nums[i] = firstNum;
                        nums.Remove(secondNum);
                    }

                }
            }

            Console.WriteLine(String.Join(" ", nums));
        }

        static bool HasAdjacentEqualNums(List<int> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
            {
                // Check if the current element is equal to the next element
                if (nums[i] == nums[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
