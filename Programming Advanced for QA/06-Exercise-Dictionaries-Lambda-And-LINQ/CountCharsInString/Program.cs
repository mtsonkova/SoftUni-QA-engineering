using System.Globalization;
using System.Text;

namespace CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = CountChars(input);
            Console.WriteLine(result);
        }

        public static string CountChars(string text)
        {
            char[] chars = text.ToCharArray();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();
            foreach (char c in chars)
            {
                if (c != ' ')
                {
                    if (charsCount.ContainsKey(c))
                    {
                        charsCount[c] += 1;
                    }
                    else
                    {
                        charsCount[c] = 1;
                    }

                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<char, int> entry in charsCount)
            {
                string result = $"{entry.Key} -> {entry.Value}";
                sb.Append(result);
                sb.Append(Environment.NewLine);

            }
            return sb.ToString();
        }
    }
}
