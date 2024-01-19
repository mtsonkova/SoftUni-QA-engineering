namespace VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int vowels = CountVowels(text);
            Console.WriteLine(vowels);
        }

        public static int CountVowels(string text)
        {
            text = text.ToLower();
            int vowelsCounter = 0;

            for (int i = 0; i <= text.Length - 1; i++)
            {
                //Console.WriteLine(text[i]);
                if (text[i] == 'a' || text[i] == 'e' || text[i] == 'i' || text[i] == 'o' || text[i] == 'u')
                {
                    vowelsCounter++;
                }

            }
            return vowelsCounter;
        }
    }
}
