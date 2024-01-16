namespace GausTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> nums = new List<int>();

            for(int i = 0; i < numbers.Length / 2; i++) {
                int firstNum = numbers[i];
                int secondNum = numbers[numbers.Length - 1 - i];
                nums.Add(firstNum + secondNum);
            }

            if(numbers.Length % 2 != 0)
            {
                nums.Add(numbers[numbers.Length / 2]);
            }

            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
