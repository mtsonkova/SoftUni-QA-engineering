using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();
           bool isValidLength = CheckPassLength(text);
            bool hasAtLeastTwoDigits = CheckDigitsCount(text);
            bool hasSpecialCharacters = CheckIfPassHasSpecialCharacters(text);
            string output = "";
            
            if(isValidLength && hasAtLeastTwoDigits && hasSpecialCharacters == false)
            {
                output = "Password is valid";
                Console.WriteLine(output);
            }

            if(isValidLength == false)
            {
                output = "Password must be between 6 and 10 characters";
                Console.WriteLine(output);
            }
            if(hasSpecialCharacters == true)
            {
                output = "Password must consist only of letters and digits";
                Console.WriteLine(output);
            } 
            if(hasAtLeastTwoDigits == false)
            {
                output = "Password must have at least 2 digits";
                Console.WriteLine(output);
            }
        }

        public static bool CheckPassLength(string text)
        {
            if(text.Length >= 6 && text.Length <= 10)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public static bool CheckDigitsCount(string text)
        {
            bool hasTwoOrMoreDigits = false;
            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            int digitsCounter = 0;

            for(int i = 0; i < digits.Length; i++)
            {
                if (text.Contains(digits[i]))
                {
                    digitsCounter++;
                    if(digitsCounter >= 2)
                    {
                        hasTwoOrMoreDigits = true;
                        break;
                    }
                }
            }
            return hasTwoOrMoreDigits;
        }

        public static bool CheckIfPassHasSpecialCharacters(string text)
        {
            bool hasSpecialChars = false;
            char[] specialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '=', '_', '+', '[', ']', '{', '}', '|', ';', ':', '\\', '\"', ',', '.', '<', '>', '?', '/', '`', '~' };
            for (int i = 0; i < specialSymbols.Length; i++)
            {
                if (text.Contains(specialSymbols[i]))
                {
                    hasSpecialChars = true;
                    
                }
            }
            return hasSpecialChars;
        }
    }
}
