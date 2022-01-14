using System;
using System.Collections.Generic;

namespace CryptographyChap8
{
    class Program
    {
        public static char[] makeKey()
        {
            char[] toReturn = new char[95];
            Random rand = new Random();
            int random = 0;
            List<int> randomList = new List<int>();
            for (int i = 0; i<toReturn.Length; i++)
            {
                do
                {
                    random = rand.Next(32, 96);
                } while (randomList.Contains(random));
               toReturn[i] = (char)random;
            }
            return toReturn;
        }
        public static string encrypt(string message, char[] key)
        {
            string toReturn = "";
            for(int i = 0; i<message.Length;i++)
            {
                int index = (char)message[i] - 32;
                toReturn += key[index];
            }
            return toReturn;
        }
        // 
        public static string decrypt(string encrypted, char[] key)
        {
            string toReturn = "";
            for (int i = 0; i < encrypted.Length; i++)
            {
                int currentChar = encrypted[i] - 32;
                toReturn += key[currentChar];
            }
            return toReturn;
        }
        static void Main(string[] args)
        {
            string message = "test";
            char[] key = makeKey();
            string encrypted = encrypt(message, key);
            string decrypted = decrypt(encrypted, key);
            Console.WriteLine(message);
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
        }
    }
}
