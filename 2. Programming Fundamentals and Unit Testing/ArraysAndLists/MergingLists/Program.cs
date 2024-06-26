using System.Net.Http.Headers;

namespace MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> merged = new List<int>();

            bool isFirstBigger = first.Count > second.Count;

            int n = Math.Min(first.Count, second.Count);

            for(int i = 0; i < n; i++)
            {
                merged.Add(first[i]);
                merged.Add(second[i]);
            }

            if(isFirstBigger)
            {
                for(int i = n; i < first.Count; i++)
                {
                    merged.Add(first[i]);
                }
            } else
            {
                for (int i = n; i < second.Count; i++)
                {
                    merged.Add(second[i]);
                }
            }

            Console.WriteLine(String.Join(" ", merged));
        }
    }
}
