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
            Array.Sort(b);
            System.Console.WriteLine($"Array.Sort executed in {sw.ElapsedMilliseconds}ms");

            sw = Stopwatch.StartNew();
            _comparisons = 0;
            int[] a1 = (int[])a.Clone();
            QuickSortUsingFirstItem(a1, 0, a1.Count() - 1);
            System.Console.WriteLine($"QuickSort using first item executed in {sw.ElapsedMilliseconds}ms,  comparisons={_comparisons}");

            sw = Stopwatch.StartNew();
            _comparisons = 0;
            int[] a2 = (int[])a.Clone();
            QuickSortUsingLastItem(a2, 0, a2.Count() - 1);
            System.Console.WriteLine($"QuickSort using last item executed in {sw.ElapsedMilliseconds}ms,  comparisons={_comparisons}");


            for (int i = 0; i < a.Count(); i++)
                if (a1[i] != b[i])
                    throw new Exception("Quicksort using first item failed");

            for (int i = 0; i < a.Count(); i++)
                if (a2[i] != b[i])
                    throw new Exception("Quicksort using last item failed");
        }

        private static void QuickSortUsingFirstItem(int[] a, int left, int right)
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

            QuickSortUsingFirstItem(a, left, i - 2);
            QuickSortUsingFirstItem(a, i, right);
        }

         private static void QuickSortUsingLastItem(int[] a, int left, int right)
        {
            int m = (right - left) + 1;

            if (m == 0 || m == 1)
                return;

            _comparisons += m - 1;

            int p = a[right];
            a[right] = a[left];
            a[left] = p;

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

            QuickSortUsingLastItem(a, left, i - 2);
            QuickSortUsingLastItem(a, i, right);
        }
        
    }
}
