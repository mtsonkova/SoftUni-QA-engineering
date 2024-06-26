namespace ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] firstArr = new int[num];
            int[] secondArr = new int[num];
           
            for(int i = 0; i < num; i++)
            {
                int[] numbers = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToArray();

                if(i % 2 == 0 || i == 0)
                {
                    firstArr[i] = numbers[0];
                    secondArr[i] = numbers[1];
                } else
                {
                    firstArr[i] = numbers[1];
                    secondArr[i] = numbers[0];
                }
            }

            Console.WriteLine(String.Join(" ", firstArr));
            Console.WriteLine(String.Join(" ", secondArr));
        }

    }
}
