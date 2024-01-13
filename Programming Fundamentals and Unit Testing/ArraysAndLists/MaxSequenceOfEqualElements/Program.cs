namespace MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> longestSequence = new List<int>();
           
           
            int counter = 1;
            int oldCounter = 1;
            int oldNum = 0;
            int currentNum = 0;
            for(int i = 0; i < nums.Length - 1; i++)
            {

                if (nums[i] == nums[i + 1])
                {
                    counter++;
                    currentNum = nums[i];
                } else {
                    counter = 1;
                }
                if (oldCounter < counter)
                {
                    oldCounter = counter;
                    oldNum = nums[i];
                }             
              
            }
            for(int i = 0; i < oldCounter; i++)
            {
                longestSequence.Add(oldNum);
            }
            Console.WriteLine(String.Join(" ", longestSequence));
           
         }
    }
}
