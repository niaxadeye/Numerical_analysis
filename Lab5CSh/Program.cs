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
        public static double GFunc(double x) => Math.Log(Math.Pow(x,2)+2);

        public static double Il(double a, double b, int n, double y) => (b - a) / (2 * n) * y;
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

            double dy,In,y = 0;
            a = 0;
            b = 100;
            n = 10000000;
            if(n > 1)
            {
                dy = (b - a) / n;
                y += GFunc(a) + GFunc(b);
                for(int i = 0; i < n; i++)
                {
                    y += 2 * GFunc(a + dy * i);
                }
                In = Il(a, b, n, y);
                Console.WriteLine(In);

            }
            else
            {
                Console.WriteLine("Eroor");
            }
            Console.ReadKey();

            a = 0;
            b = 100;
            double eps = 0.0001;

            I = eps + 1;
            double I1 = 0;
            for (int N = 2; (N <= 4) || Math.Abs(I1 - I) > eps; N *= 2)
            {
                double sum2 = 0, sum4 = 0, sum = 0;
                h = (b - a) / (2 * N);
                for (int i = 1; i <= 2 * N; i += 2)
                {
                    sum4 += GFunc(a + h * i);
                    sum2 += GFunc(a + h * (i + 1));
                }
                sum = GFunc(a) + 4 * sum4 + 2 * sum2 - GFunc(b);
                I = I1;
                I1 = (h / 3) * sum;
            }
            Console.WriteLine(I1);
            Console.ReadKey();
        }
            
    }
}
