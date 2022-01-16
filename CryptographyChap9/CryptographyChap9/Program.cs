using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyChap9
{
    
    class Program
    {
        public static string inputPhonetic(string inputNormal)
        {
            string input = inputNormal.ToLower();
            int characterValue = 0;
            StringBuilder toReturn = new StringBuilder();
            bool matched = false;

            Dictionary<char, int> charMap = new Dictionary<char, int>();
            bool first = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (!charMap.ContainsKey(input[i]))
                {
                    characterValue++;
                    charMap.Add(input[i], characterValue);
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                int value = charMap[input[i]];
                if (first)
                {
                    toReturn.Append($"value");
                    first = false;
                }
                else
                {
                    toReturn.Append($".{value}");
                }
            }
            return toReturn.ToString();
        }
        static void Main(string[] args)
        {
            string input = "aaa";
            string returned = inputPhonetic(input);
            Console.WriteLine(input);
            Console.WriteLine(returned);
        }
    }
}
