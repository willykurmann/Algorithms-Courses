using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace InversionsCount
{
    class Program
    {
        private static double inversionsCount = 0;
        static void Main(string[] args)
        {
            double[] a = File.ReadAllLines("IntegerArray.txt")
            .Select(x => double.Parse(x))
            .ToArray();

            System.Console.WriteLine(string.Format("Number of items in array: {0}", a.Count()));

            Stopwatch sw = Stopwatch.StartNew();
            double[] c = CountInversions(a);
            sw.Stop();

            System.Console.WriteLine(string.Format("Number of inversions: {0}, elapsed time: {1}ms", inversionsCount, sw.ElapsedMilliseconds));
        }
        private static double[] CountInversions(double[] a)
        {
            int n = a.Count();

            if (n == 1)
                return a;
            
            int m = n % 2 == 0 ? n / 2 : (n + 1) / 2;

            var left = CountInversions(a.Take(m).ToArray());
            var right = CountInversions(a.Skip(m).ToArray());
            var result = SortAndCount(left,right);

            return result;
        }

        private static double[] SortAndCount(double[] a, double[] b)
        {
            int i = 0;
            int j = 0;
            var result = new List<double>();

            while (i < a.Count() && j < b.Count())
            {
                if (a[i] <= b[j])
                {
                    result.Add(a[i]);
                    i++;
                }
                else
                {
                    result.Add(b[j]);
                    j++;
                    inversionsCount += (a.Count() - i);
                }
            }

            if (i == a.Count())
            {
                result.AddRange(b.Skip(j));
            }
            else
            {
                result.AddRange(a.Skip(i));
            }
            
            return result.ToArray();
        }
    }
}
