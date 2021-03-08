using System;
using System.Collections.Generic;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new List<string> { "A", "B", "C", "D" };
            int k = 3;
            KSubsets(ls, k);
        }

        static void KSubsets(List<string> ls, int k)
        {
            var results = new List<string>();
            Console.WriteLine("Using KSubsets1");
            KSubsets1(ls, results, k);
            Console.WriteLine("Using KSubsets2");
            KSubsets2(ls, results, k);
            Console.WriteLine("Using KSubsets3");
            KSubsets3(ls, 0, results, k);
            Console.WriteLine("Using KSubsets4");
            KSubsets4(ls, 0, k);
        }

        static void PrintList(List<string> ls)
        {
            Console.Write(" { ");
            foreach (string s in ls)
                Console.Write(s + " ");
            Console.WriteLine("}");
        }

        static void KSubsets1(List<string> ls, List<string> results, int k)
        {
            if (ls.Count == 0)
            {
                if (results.Count == k)
                {
                    PrintList(results);
                    return;
                }
                else return;
            }
            var newList = new List<string>(ls);
            var newResults = new List<string>(results);
            string s = newList[0];
            newList.RemoveAt(0);
            KSubsets1(newList, newResults, k);
            newResults.Add(s);
            KSubsets1(newList, newResults, k);
        }

        static void KSubsets2(List<string> ls, List<string> results, int k)
        {
            if (ls.Count == 0)
            {
                if (results.Count == k)
                {
                    PrintList(results);
                    return;
                }
                else return;
            }
            string s = ls[0];
            ls.RemoveAt(0);
            KSubsets2(ls, results, k);
            results.Add(s);
            KSubsets2(ls, results, k);
            results.RemoveAt(results.Count - 1);
            ls.Insert(0, s);
        }

        static void KSubsets3(List<string> ls, int l, List<string> results, int k)
        {
            if (ls.Count == l)
            {
                if (results.Count == k)
                {
                    PrintList(results);
                    return;
                }
                else return;
            }
            string s = ls[l];
            KSubsets3(ls, l + 1, results, k);
            results.Add(s);
            KSubsets3(ls, l + 1, results, k);
            results.RemoveAt(results.Count - 1);
        }

        static void KSubsets4(List<string> ls, int l, int k)
        {
            if (ls.Count == l)
            {
                if (l == k)
                {
                    PrintList(ls);
                    return;
                }
                else return;
            }
            string s = ls[l];
            ls.RemoveAt(l);
            KSubsets4(ls, l, k);
            ls.Insert(l, s);
            KSubsets4(ls, l + 1, k);
        }
    }
}
