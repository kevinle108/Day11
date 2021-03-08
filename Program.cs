using System;
using System.Collections.Generic;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new List<string> { "A", "B", "C" };
            int k = 1;
            KPermutations(ls, k);
        }

        static void KPermutations(List<string> ls, int k)
        {
            var results = new List<string>();
            Console.WriteLine("Using KPermutations1");
            KPermutations1(ls, results, k);
            Console.WriteLine("Using Permutations2");
            KPermutations2(ls, 0, k);
        }

        static void KPermutations1(List<string> ls, List<string> results, int k)
        {
            if (results.Count == k)
            {
                PrintList(results);
                return;
            }
            if (ls.Count == 0) return;
            for (int i = 0; i < ls.Count; i++)
            {
                var newList = new List<string>(ls);
                var newResults = new List<string>(results);
                newList.RemoveAt(i);
                newResults.Add(ls[i]);
                KPermutations1(newList, newResults, k);
            }
        }
        static void KPermutations2(List<string> ls, int l, int k)
        {
            if (l == k)
            {
                PrintList(ls.GetRange(0, k));
                return;
            }
            for (int i = l; i < ls.Count; i++)
            {
                Swap(ls, i, l);
                KPermutations2(ls, l + 1, k);
                Swap(ls, i, l);
            }
        }

        static void Swap(List<string> ls, int i, int j)
        {
            string tmp = ls[i];
            ls[i] = ls[j];
            ls[j] = tmp;
        }

        static void PrintList(List<string> ls)
        {
            Console.Write(" { ");
            foreach (string s in ls)
                Console.Write(s + " ");
            Console.WriteLine("}");
        }
    }
}
