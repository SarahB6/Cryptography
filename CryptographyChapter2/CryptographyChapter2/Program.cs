using System;
using System.Collections.Generic;

namespace CryptographyChap2Assignment
{
    class Program
    {
        static List<int> getAllFactors(int integer)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= integer; i++)
            {
                if (integer % i == 0)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        static void print(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        static int GCF(int integer1, int integer2)
        {

            int max;
            int num = 0;
            if (integer1 > integer2)
            {
                max = integer2;
            }
            else
            {
                max = integer1;
            }
            for (int i = 1; i <= max; i++)
            {
                if (integer1 % i == 0 && integer2 % i == 0)
                {
                    if (i > num)
                    {
                        num = i;
                    }
                }
            }
            return num;
        }
        static int GCF2(int integer1, int integer2)
        {
            while (integer2 != integer1)
            {
                if (integer1 > integer2)
                {
                    integer1 -= integer2;
                }
                else
                {
                    integer2 -= integer1;
                }
            }
            return integer1;
        }

        static bool checkRelativePrime(int integer1, int integer2)
        {
            return GCF2(integer1, integer2) == 1;
        }

        static bool checkPrime(int integer)
        {
            return getAllFactors(integer).Count == 2;
        }

        static void printFirstEightMersennePrime()
        {

        }

        static void printUniquePairsRelativePrime()
        {

        }

        static void printAllPosssiblePermutations(string str)
        {

        }


        static void Main(string[] args)
        {
            List<int> list = getAllFactors(8);
            print(list);
            Console.WriteLine(GCF2(12, 8));
        }
    }
}
