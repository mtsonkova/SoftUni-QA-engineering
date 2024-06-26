using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondtNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            string productStatus = CheckProductStatus(firstNum, secondtNum, thirdNum);
            Console.WriteLine(productStatus);
        }

        public static string CheckProductStatus(int firstNum, int secondNum, int thirdNum)
        {
            string status = "";

            if (firstNum > 0 && secondNum > 0 && thirdNum > 0)
            {
                status = "positive";
            }

            else if (firstNum < 0 || secondNum < 0 || thirdNum < 0)
            {
                int negativeCounter = 0;
                if ((firstNum < 0 && secondNum < 0) || (firstNum < 0 && thirdNum < 0) ||
                    (secondNum < 0 && thirdNum < 0))
                {
                    negativeCounter = 2;
                }

                if (negativeCounter == 2)
                {
                    status = "positive";
                }
                else
                {
                    status = "negative";
                }
            }
            else if (firstNum == 0 || secondNum == 0 || thirdNum == 0)
            {
                status = "zero";
            }

            return status;
        }
    }
}

