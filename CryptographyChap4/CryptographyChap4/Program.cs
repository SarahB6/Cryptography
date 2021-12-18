using System;

namespace CryptographyChap4
{
    class Program
    {
        public static string compress(string input)
        {
            string toReturn = "";
            char pastChar = input[0];
            int integer = 0;
            if (input == "")
            {
                return "0";
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == pastChar)
                {
                    integer++;
                }
                else
                {
                    toReturn += $"{pastChar}{integer}";
                    pastChar = input[i];
                    integer = 1;
                }
            }
            toReturn += $"{pastChar}{integer}";
            return toReturn;
        }

        public static string decompress(string input)
        {
            string toReturn = "";
            char currentChar = ' ';
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] < '9')
                {
                    int times = input[i] - '0';
                    for (int a = 0; a < times; a++)
                    {
                        toReturn += input[i - 1];
                    }
                }
            }
            return toReturn;
        }

        static void Main(string[] args)
        {
            string compressed = compress("aabbccd");
            string decompressed = decompress(compressed);
            Console.WriteLine(decompressed);
        }
    }
}
