using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Assignment_3
{
    class Program
    {
        private static int _comparisons = 0;

        static void Main(string[] args)
        {
            int[] a = File.ReadAllLines("QuickSort.txt")
            .Select(x => int.Parse(x))
            .ToArray();

            int[] b = (int[])a.Clone();

            Stopwatch sw = Stopwatch.StartNew();

            QuickSort(a, 0, a.Count() - 1);
            System.Console.WriteLine($"QuickSort executed in {sw.ElapsedMilliseconds}ms");

            Array.Sort(b);
            System.Console.WriteLine($"Sorted executed in {sw.ElapsedMilliseconds}ms");

            for (int i = 0; i < a.Count(); i++)
                if (a[i] != b[i])
                    throw new Exception("not equally sorted");

            System.Console.WriteLine($"Comparisons={_comparisons}");
        }

        private static void QuickSort(int[] a, int left, int right)
        {
            int m = (right - left) + 1;

            if (m == 0 || m == 1)
                return;

            _comparisons += m - 1;

            int p = a[left];
            int i = left + 1;

            for (int j = i; j <= right; j++)
            {
                if (a[j] < p)
                {
                    int swap = a[j];
                    a[j] = a[i];
                    a[i] = swap;
                    i = i + 1;
                }
            }

            int swapL = a[left];
            a[left] = a[i - 1];
            a[i - 1] = swapL;

            QuickSort(a, left, i - 2);
            QuickSort(a, i, right);
        }
    }
}
