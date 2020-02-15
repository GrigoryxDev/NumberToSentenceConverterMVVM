using System.Numerics;
using System.Text.RegularExpressions;


namespace NumberToSentenceConverter.Models
{
    public class Converter
    {
        public static string ToSentence(string inputValue) => m_ToSentence(inputValue);
        private static string m_ToSentence(string value)
        {
            string result;

            if (value == null || Regex.IsMatch(value, "[^0-9]") || value == string.Empty)
            {
                result = "Please enter only one positive number";
                return result;
            }
            if (value[0] == '0' && value.Length == 1)
            {
                result = "Zero";
            }
            else if (BigInteger.Parse(value) <= 9)
            {
                result = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }[(int)BigInteger.Parse(value) - 1] + " ";
            }
            else if (BigInteger.Parse(value) <= 19)
            {
                result = new[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" }[(int)BigInteger.Parse(value) - 10] + " ";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 2) - 1)
            {
                result = new[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" }[(int)BigInteger.Parse(value) / 10 - 2] + (BigInteger.Parse(value) % 10 > 0 ? " " + m_ToSentence($"{BigInteger.Parse(value) % 10}") : null);
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 3) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 2)}")}Hundred {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 2)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 6) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 3)}")}Thousand {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 3)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 9) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 6)}")}Million {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 6)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 12) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 9)}")}Milliard {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 9)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 15) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 12)}")}Billion {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 12)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 18) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 15)}")}Billiard {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 15)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 24) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 18)}")}Trillion {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 18)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 30) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 24)}")}Quadrillion {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 24)}")}";
            }
            else if (BigInteger.Parse(value) <= BigInteger.Pow(10, 36) - 1)
            {
                result = $"{m_ToSentence($"{BigInteger.Parse(value) / BigInteger.Pow(10, 30)}")}Quintillion {m_ToSentence($"{BigInteger.Parse(value) % BigInteger.Pow(10, 30)}")}";
            }
            else
                result = $"Sorry, but your number is so big and incredible that i can't imagine it";
            return result;
        }
    }
}

