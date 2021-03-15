using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        public static double Func(double x) => 1 / Math.Sqrt(5 - Math.Pow(x, 2));
        static void Main(string[] args)
        {
            double a, b;
            Console.Write("Введите eps: ");
            double eps = Convert.ToDouble(Console.ReadLine());
            a = 0;
            b = 1;
            double h;
            double I = eps + 1;
            double I1 = 0;
            for (int N = 2; (N <= 4) || Math.Abs(I1 - I) > eps; N *= 2)
            {
                double sum2 = 0, sum4 = 0, sum;
                h = (b - a) / (2 * N);
                for (int i = 1; i <= 2 * N; i += 2)
                {
                    sum4 += Func(a + h * i);
                    sum2 += Func(a + h * (i + 1));
                }
                sum = Func(a) + 4 * sum4 + 2 * sum2 - Func(b);
                I = I1;
                I1 = (h / 3) * sum;
            }
            Console.WriteLine(I1);
            Console.ReadKey();
        }
    }
}
