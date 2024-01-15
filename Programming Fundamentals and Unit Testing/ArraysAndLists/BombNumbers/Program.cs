namespace BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToList();
            int[] bombInfo = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToArray();
            int bomb = bombInfo[0];
            int bombPower = bombInfo[1];
            //1 4 4 2 8 9 1
            //9 3

            while (nums.Contains(bomb))
            {
                int bombIndex = nums.IndexOf(bomb);
                int startIndex = bombIndex - bombPower;
                int endIndex = bombIndex + bombPower;

                if (startIndex < 0) { startIndex = 0; }
                if (endIndex > nums.Count - 1) { endIndex = nums.Count - 1; }
                int elementCounter = 0;

                for (int i = startIndex; i <= endIndex; i++)
                {
                    elementCounter++;
                }

                nums.RemoveRange(startIndex, elementCounter);

            }

            int sum = nums.Sum();

            Console.WriteLine(sum);

            //1 4 4 2 8 9 1
            //9 3

        }
    }
}
