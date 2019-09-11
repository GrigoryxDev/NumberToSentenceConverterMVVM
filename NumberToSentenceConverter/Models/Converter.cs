using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumberToSentenceConverter.Models
{
    public class Converter
    {
        public static string toSentence(string inputValue) => ToSentence(inputValue);
        private static string ToSentence(string value)
        {
            var userNumber = BigInteger.Parse(value);
            string result;
            if (value[0] == '0')
            {
                result = "Zero";
            }
            else if (userNumber <= 9)
            {
                result = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }[(int)userNumber - 1] + " ";
            }
            else if (userNumber <= 19)
            {
                result = new[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" }[(int)userNumber - 10] + " ";
            }
            else if (userNumber <= BigInteger.Pow(10, 2) - 1)
            {
                result = new[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" }[(int)userNumber / 10 - 2] + (userNumber % 10 > 0 ? " " + ToSentence($"{userNumber % 10}") : null);
            }
            else if (userNumber <= BigInteger.Pow(10, 3) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 2)}")}Hundred {ToSentence($"{userNumber % BigInteger.Pow(10, 2)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 6) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 3)}")}Thousand {ToSentence($"{userNumber % BigInteger.Pow(10, 3)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 9) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 6)}")}Million {ToSentence($"{userNumber % BigInteger.Pow(10, 6)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 12) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 9)}")}Milliard {ToSentence($"{userNumber % BigInteger.Pow(10, 9)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 15) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 12)}")}Billion {ToSentence($"{userNumber % BigInteger.Pow(10, 12)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 18) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 15)}")}Billiard {ToSentence($"{userNumber % BigInteger.Pow(10, 15)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 24) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 18)}")}Trillion {ToSentence($"{userNumber % BigInteger.Pow(10, 18)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 30) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 24)}")}Quadrillion {ToSentence($"{userNumber % BigInteger.Pow(10, 24)}")}";
            }
            else if (userNumber <= BigInteger.Pow(10, 36) - 1)
            {
                result = $"{ToSentence($"{userNumber / BigInteger.Pow(10, 30)}")}Quintillion {ToSentence($"{userNumber % BigInteger.Pow(10, 30)}")}";
            }
            else
                result = $"Sorry, but your number is so big and incredible that i can't imagine it,let's call it XXXellion";
            return result;
        }
    }
}

