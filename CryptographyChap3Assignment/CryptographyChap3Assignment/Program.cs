using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CryptographyChap3Assignment
{
    class Program
    {
        public static string Encrypt(string input, int key)
        {
            string encrypted = "";
            for (int i = 0; i < input.Length; i++)
            {
                int num = ((input[i] - 97) + key);
                int offset = 0;
                if (num < 0)
                {
                    offset = num + 26 + 97;
                }
                else
                {
                   offset = num % 26 + 97;
                }
                encrypted += (char)offset;
            }
            return encrypted;
        }

        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, -key);
        }

        public static string[] allPossibleMessages(string input)
        {
            string[] toReturn = new string[26];
            for (int i = 0; i<toReturn.Length; i++)
            {
                toReturn[i] = Decrypt(input, i);
            }
            return toReturn;
        }
        
        public static string inputPhonetic(string inputNormal)
        {
            string input = inputNormal.ToLower();
            int characterValue = 0;
            StringBuilder toReturn = new StringBuilder();
            bool matched = false;

            Dictionary<char, int> charMap = new Dictionary<char, int>();

            for (int i = 0; i<input.Length; i++)
            {
                if (!charMap.ContainsKey(input[i]))
                {
                    characterValue++;
                    charMap.Add(input[i], characterValue);
                }
            }

            for (int i = 0; i<input.Length; i++)
            {
                int value = charMap[input[i]];
                toReturn.Append($".{value}");
            }
            return toReturn.ToString();
        }

        public static string[] SmartCracker(string input)
        {
            List<string> words = new List<string>(System.IO.File.ReadAllLines("words.txt"));
            string inputMap = inputPhonetic(input);
            List<string> possibles = new List<string>();
            List<string> realPossible = new List<string>();
            for (int i = 0; i<words.Count;i++)
            {
                string wordMap = inputPhonetic(words[i]);
                if (inputMap.Equals(wordMap))
                {
                    possibles.Add(words[i]);
                }
            }
            for (int i = 0; i<26; i++)
            {
                for (int a = 0; a < possibles.Count; a++)
                {
                    if (Decrypt(input, i) == possibles[a])
                    {
                        realPossible.Add(possibles[a]);
                    }
                }
            }
            return realPossible.ToArray();
        } 

        public static string doubleEncryption(string input, int key, int key2)
        {
            string encrypted = Encrypt(input, key);
            return Encrypt(encrypted, key2);
        }

        static void Main(string[] args)
        {

            string input = "chicken";
            int key = 4;
            int key2 = 2;
            string encrypted = Encrypt(input, key);
            string decrypted = Decrypt(encrypted, key);
            string doubleEncrypt = doubleEncryption(input, key, key2);
            Console.WriteLine(input);
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
            Console.WriteLine(doubleEncrypt);
            string[] returned = allPossibleMessages(encrypted);
            for (int i = 0; i < returned.Length; i++)
            {
                Console.WriteLine(returned[i]);
            }
            string[] returnedPossibles = SmartCracker(encrypted);
            for (int i = 0; i<returnedPossibles.Length; i++)
            {
                Console.WriteLine(returnedPossibles[i]);
            }

        }
    }
}
