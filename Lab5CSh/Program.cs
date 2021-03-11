using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5CSh
{
    class Program
    {
        public static double Func(double x) => 1 / Math.Sqrt(5 - Math.Pow(x, 2));
        public static double GFunc(double x) =>Math.Log(Math.Pow(x,2)+2);
        static void Main(string[] args)
        {
            double a, b;
            int n;
            a = 0;
            b = 100;
            n = 1000;
            double s = (GFunc(a) + GFunc(b)) / 2;
            double h = (b - a) / n;
            for(int i = 1; i <=n-1; i++)
            {
                s += GFunc(a + i * h);
            }
            double I = h * s;
            Console.WriteLine(I);
            Console.ReadKey();
        }
    }
}
