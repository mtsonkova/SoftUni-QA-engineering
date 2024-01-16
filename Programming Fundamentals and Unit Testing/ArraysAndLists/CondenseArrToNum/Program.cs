namespace CondenseArrToNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            while (nums.Count > 1)
            {
                for (int i = 0; i < nums.Count - 1; i++)
                {
                        nums[i] += nums[i + 1];                                   

                }
                nums.Remove(nums[nums.Count - 1]);
               
            }
            Console.WriteLine(nums[0]);
        }
    }
}
