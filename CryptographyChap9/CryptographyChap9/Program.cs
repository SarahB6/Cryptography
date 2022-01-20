using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CryptographyChap9
{
    
    class Program
    {
        public static string[] checkAllWords()
        {
            List<string> words = new List<string>(System.IO.File.ReadAllLines("wordsforchap9.txt"));
            string[] toReturn = new string[words.Count];
            for (int i = 0; i<words.Count; i++)
            {
                toReturn[i] = inputPhonetic(words[i]);
            }
            return toReturn;
        }

        public static Dictionary<string, List<string>> allWordsSamePattern()
        {
            Dictionary<string, List<string>> toReturn = new Dictionary<string, List<string>>();
            List<string> words = new List<string>(System.IO.File.ReadAllLines("wordsforchap9.txt"));
            //string[] allWordsPhonetics = checkAllWords();

            for (int wordIndex = 0; wordIndex < words.Count; wordIndex++)
            {
                string frequency = inputPhonetic(words[wordIndex]);
                if (!toReturn.ContainsKey(frequency))
                {
                    toReturn.Add(frequency, new List<string>());
                }
                toReturn[frequency].Add(words[wordIndex]);
            }
            return toReturn;
        }
        public static List<string> wordsWithSamePattern(string word, Dictionary<string, List<string>> dict)
        {
            List<string> toReturn = new List<string>();
            string frequency = inputPhonetic(word);
            toReturn = dict[frequency];
            return toReturn;
        }
        public static string inputPhonetic(string inputNormal)
        {
            string input = inputNormal.ToLower();
            int characterValue = 0;
            StringBuilder toReturn = new StringBuilder();

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
                    toReturn.Append(value);
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
            string input = "test";
            string returned = inputPhonetic(input);
            string[] allWords = checkAllWords();
            Dictionary<string, List<string>> Dict = allWordsSamePattern(); 
            Console.WriteLine(input);
            Console.WriteLine(returned);
            Console.WriteLine(allWords[4]);
            List<string> list = wordsWithSamePattern("checking", Dict);
            for(int i = 0; i<list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }
    }
}
