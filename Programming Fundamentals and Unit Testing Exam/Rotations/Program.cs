namespace Rotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rotationsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotationsNum; i++)
            {
                int currentLastNum = arr[arr.Length - 1];
                for (int j = arr.Length - 1; j > 0; j--)
                {
                    arr[j] = arr[j - 1];
                }

                arr[0] = currentLastNum;
            }

            string[] rotetedArr = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                rotetedArr[i] = arr[i].ToString();
            }

            Console.WriteLine(String.Join(", ", rotetedArr));
        }
    }
}