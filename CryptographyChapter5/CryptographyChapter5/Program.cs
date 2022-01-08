using System;


namespace CryptographyChap5
{
    class Program
    {
        static (int min, int max) printableRange = (32, 127);
        
        public static string createKey(string input)
        {
            Random ran = new Random();
            string str = "";
            int letter = -1;

            for (int i = 0; i < input.Length; i++)
            {
                letter = ran.Next(printableRange.min, printableRange.max + 1);

                str += (char)letter;
            }
            return str;
        }
        public static string encrypt(string input, string key)
        {

            string str = "";
            int range = printableRange.max - printableRange.min + 1;

            for (int i = 0; i < input.Length; i++)
            {
                int keyValue = key[i];

                int num = ((input[i] - printableRange.min) + keyValue) % range + printableRange.min;

                str += (char)num;
            }
            return str;
        }
        //((input-32)+keyvalue)%range+printableRange.min = output
        //((output-32)-keyvalue)%range+printableRange.min=input
        public static string decrypt(string input, string key)
        {
            string str = "";
            string inti = "";
            int range = printableRange.max - printableRange.min +1; // is this the right range??

            for (int i = 0; i < input.Length; i++)
            {
                int keyValue = key[i] - printableRange.min;

                int num = (((input[i]+printableRange.min) - keyValue)+range)%range + printableRange.min;
                inti += $"{num}  ";
                str += (char)num;
            }
            return str; 
        }
        static void Main(string[] args)
        {
            string input = "Am5";
            string key = createKey(input);
            Console.WriteLine(key);
            string encrypted = encrypt(input, key);
            Console.WriteLine(encrypted);
            string decrypted = decrypt(encrypted, key);
            Console.WriteLine(decrypted);
        }
    }
}
