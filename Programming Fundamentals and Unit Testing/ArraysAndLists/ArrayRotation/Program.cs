namespace ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] arr = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToArray();
           int num = int.Parse(Console.ReadLine());

            for(int i = 0; i < num; i++)
            {
                int firstNum = arr[0];
                for(int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[ j+ 1];
                }
                arr[arr.Length - 1] = firstNum;
            }

            Console.WriteLine(string.Join(" ", arr));


        }
    }
}
