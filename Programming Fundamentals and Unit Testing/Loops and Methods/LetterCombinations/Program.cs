using System.Xml;

namespace LetterCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startLetter = Console.ReadLine()[0];
            char endLetter = Console.ReadLine()[0];
            char excludedLetter = Console.ReadLine()[0];

            List<string> result = new List<string>();

            for (char firstChar = startLetter; firstChar <= endLetter; firstChar++)
            {
                if (firstChar != excludedLetter)
                {
                    for (char secondChar = startLetter; secondChar <= endLetter; secondChar++)
                    {
                        if(secondChar != excludedLetter)
                        {
                            for( char thirdChar = startLetter; thirdChar <= endLetter; thirdChar++)
                            {
                                if (thirdChar != excludedLetter)
                                {
                                    string letters = firstChar.ToString() + secondChar.ToString() + thirdChar.ToString();
                                    result.Add(letters);
                                }
                            }
                        }
                    }
                }
            }          

            Console.WriteLine(String.Join(" ", result));
            Console.WriteLine(result.Count);
                }
    }
}
