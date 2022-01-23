using System;

namespace CryptographyChap10
{
    class Program
    {
        public static string toPrint(char[,] returned)
        {
            string toReturn = "";
            for (int row = 0; row < returned.GetLength(0); row++)
            {
                string returning = "";
                for (int col = 0; col < returned.GetLength(1); col++)
                {
                    returning += $"{returned[row, col]}";
                }
                toReturn += $"{returning}\n";
            }
            return toReturn;
        }
        public static char[,] makeTabulaRecta()
        {
            char[,] toReturn = new char[26, 26];
            int value = 97;
            for (int i = 0; i < toReturn.GetLength(0); i++)
            {
                value = 'a' + i;
                for (int a = 0; a < toReturn.GetLength(1); a++)
                {

                    if (value > 'z')
                    {
                        value = 'a';
                    }
                    toReturn[i, a] = (char)value;
                    value++;
                }
            }
            return toReturn;
        }
        public static string fixKey(string input, string key)
        {
            int letters = 0;
            //Count number of LETTERS in input
            //Find the difference between that number and the keys length
            //Loop for the difference adding the key to itself
            for (int i = 0; i<input.Length; i++)
            {
                if(char.IsLetter(input[i]))
                {
                    letters++;
                }
            }
            int diff = letters-key.Length;
            for(int i = 0; i<diff; i++)
            {
                key += key[i % key.Length];
            }
            return key;
        }
        public static string encrypt(string input, string keyFirst)
        {
            string toReturn = "";
            char[,] chart = makeTabulaRecta();
            string key = fixKey(input, keyFirst);

            int keyIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) == false)
                {
                    toReturn += input[i];
                    continue;
                }

                int inputValue = input[i] - 'a';
                int keyValue = key[keyIndex++] - 'a';
                toReturn += chart[inputValue, keyValue];
            }
            return toReturn;
        }

        public static string decrypt(string encrypted, string keyFirst)
        {
            string toReturn = "";
            char[,] chart = makeTabulaRecta();
            string key = fixKey(encrypted, keyFirst);
            int keyValue = 0;
            for (int i = 0; i < encrypted.Length; i++)
            {
                if (char.IsLetter(encrypted[i]) == false)
                {
                    toReturn += encrypted[i];
                    continue;
                }
                
                for (int a = 0; a < chart.GetLength(0); a++)
                {
                    if (chart[a, key[keyValue]-'a'] == encrypted[i])
                    {
                        toReturn += (char)(a +'a');
                    }
                }
                keyValue++;

            }
            return toReturn;
        }
        static void Main(string[] args)
        {
            string input = "teioopew9ewijoewsfo9ipweoi9pweeoiwk";
            string key = "pizza";
            string encrypted = encrypt(input, key);
            string decrypted = decrypt(encrypted, key);
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
            Console.WriteLine(decrypted == input);
            //Print if encrypted is the same as input
        }
    }
}
