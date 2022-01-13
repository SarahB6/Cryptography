using System;

namespace CryptographyChap7
{
    class Program
    {
        public static string[,] encode(string input, int key)
        {
            int numRows = (int)Math.Ceiling((double)input.Length/key);
            int numCol = key;
            int count = 0;
            bool hasAstrisk = false; // *
            bool hasHash = false; // #
            bool hasCaret = false; // ^
            bool hasTilde = false; // ~
            string[,] toReturn = new string[numRows,numCol];
            for (int col = 0; col<numCol; col++)
            {
                for (int row = 0; row<numRows; row++)
                {
                    
                    if (count < input.Length)
                    {
                        if (input[count].ToString() == "*")
                        {
                            hasAstrisk = true;
                        }
                        else if (input[count].ToString() == "#")
                        {
                            hasHash = true;
                        }
                        else if (input[count].ToString() == "^")
                        {
                            hasCaret = true;
                        }
                        else if (input[count].ToString() == "~")
                        {
                            hasTilde = true;
                        }
                        toReturn[row, col] = input[count].ToString();
                        count++;
                    }
                    else
                    {
                        if (!hasAstrisk)
                        {
                            toReturn[row, col] = "*";
                        }
                        else if (!hasHash)
                        {
                            toReturn[row, col] = "#";
                        }
                        else if (!hasCaret)
                        {
                            toReturn[row, col] = "^";
                        }
                        else
                        {
                            toReturn[row, col] = "~";
                        }
                    }

                }
            }
            return toReturn;
        }
        public static string toPrint(string[,] returned)
        {
            string toReturn = "";
            for (int row = 0; row < returned.GetLength(0); row++)
            {
                string returning = "";
                for (int col = 0; col < returned.GetLength(1); col++)
                {
                    returning += $"{returned[row, col]}";
                }
                toReturn += $"{returning}";
            }
            return toReturn;
        }

        public static string decode(string[,] coded, int key)
        {
            string toReturn = "";
            for (int col = 0; col < coded.GetLength(1); col++)
            {
                for (int row = 0; row < coded.GetLength(0); row++)
                {
                    //testing
                    if (coded.GetLength(1) - 1 == col)
                    {
                        if (coded[row, col] == "*" && row != coded.GetLength(0) - 1 ||
                            coded[row, col] == "#" && row != coded.GetLength(0) - 1 ||
                            coded[row, col] == "^" && row != coded.GetLength(0) - 1 ||
                            coded[row, col] == "~" && row != coded.GetLength(0) - 1)
                        {
                            if (coded[row + 1, col] == "*" ||
                                coded[row + 1, col] == "#" ||
                                coded[row + 1, col] == "^" ||
                                coded[row + 1, col] == "~")
                            { }
                        }
                        else if (coded[row, col] == "*" && row == coded.GetLength(0) - 1 ||
                                 coded[row, col] == "#" && row == coded.GetLength(0) - 1 ||
                                 coded[row, col] == "^" && row == coded.GetLength(0) - 1 ||
                                 coded[row, col] == "~" && row == coded.GetLength(0) - 1)
                        { }
                        else
                        {
                            //works - special characters
                            toReturn += coded[row, col];
                        }
                    }
                    else
                    {
                        toReturn += coded[row, col];
                    }
                    
                }
            }
            return toReturn;
        }
        static void Main(string[] args)
        {
            string input = "check if it worked";
            int key = 5;
            string[,] encoded = encode(input, key);
            string printEncode = toPrint(encoded);
            Console.WriteLine(printEncode);
            string decoded = decode(encoded, key);
            Console.WriteLine(decoded);

        }
    }
}
