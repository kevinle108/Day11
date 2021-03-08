using System;
using System.Collections.Generic;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Paren(n);
        }

        static void Paren(int n)
        {
            Paren(n, n, new List<string>());
        }

        static void Paren(int open, int close, List<string> results)
        {
            if (open == 0) {
                List<string> printThis = new List<string>(results);
                for (int i = 0; i < close; i++)
                {
                    printThis.Add(")");
                }
                PrintList(printThis);
                return;
            }
            List<string> rightBranch = new List<string>(results);
            rightBranch.Add("(");
            Paren(open - 1, close, rightBranch);
            if (close > open)
            {
                List<string> leftBranch = new List<string>(results);
                leftBranch.Add(")");
                Paren(open, close-1, leftBranch);           
            }
        }

        static void PrintList(List<string> ls)
        {
            foreach (string s in ls) Console.Write(s);
            Console.WriteLine();
        }
    }
}
