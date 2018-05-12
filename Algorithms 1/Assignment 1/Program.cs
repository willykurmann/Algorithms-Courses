using System;
using System.Diagnostics;
using System.Numerics;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
            BigInteger y = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");
            
            System.Console.WriteLine(string.Format("Expected =  {0}", x * y));

            Stopwatch sw = Stopwatch.StartNew();
            BigInteger result = Karatsuba(x, y);
            sw.Stop();

            System.Console.WriteLine(string.Format("Karatsuba = {0}", result));
            System.Console.WriteLine(string.Format("Elapsed time = {0}ms",sw.ElapsedMilliseconds));
        }

        private static BigInteger Karatsuba(BigInteger x, BigInteger y)
        {
            string xValue = x.ToString();
            string yValue = y.ToString();

            if (xValue.Length <= 10 || yValue.Length <= 10)
                return x * y;

            int n = Math.Max(xValue.Length, yValue.Length);
            int m = n % 2 == 0 ? n / 2 : (n + 1) / 2;

            BigInteger a = BigInteger.Parse(xValue.Substring(0, m));
            BigInteger b = BigInteger.Parse(xValue.Substring(m));
            BigInteger c = BigInteger.Parse(yValue.Substring(0, m));
            BigInteger d = BigInteger.Parse(yValue.Substring(m));

            BigInteger ac = Karatsuba(a, c);
            BigInteger bd = Karatsuba(b, d);
            BigInteger abcd = Karatsuba((a + b), (c + d));

            // Gauss's trick
            BigInteger gauss = (abcd - ac- bd);

            return  BigInteger.Pow(10,n) * ac + BigInteger.Pow(10,m) * gauss + bd ;
        }

    }
}
