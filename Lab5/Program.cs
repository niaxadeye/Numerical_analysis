using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;

            double[] a = new double[n];
            a[0] = 0;

            double[] b = new double[n];
            b[0] = 2;

            double[] c = new double[n];
            c[0] = 1;

            double[] d = new double[n];
            d[0] = 120;

            double[] u = new double[n];
            u[0] = -(c[0] / b[0]);

            double[] v = new double[n];
            v[0] = d[0] / b[0];

            double[] x = new double[n];

            for(int i = 1; i < n-1; i++)
            {
                a[i] = 1;
                b[i] = 2;
                c[i] = 1;
                d[i] = 120;
                u[i] = -(c[i] / (a[i] * u[i - 1] + b[i]));
                v[i] = (d[i] - a[i] * v[i - 1]) / (a[i] * u[i - 1] + b[i]);
            }
            a[n - 1] = 1;
            b[n - 1] = 2;
            c[n - 1] = 0;
            d[n - 1] = 120;
            u[n - 1] = -(c[n - 1] / (a[n - 1] * u[n - 2] + b[n - 1]));
            v[n - 1] = (d[n - 1] - a[n - 1] * v[n - 2]) / (a[n - 1] * u[n - 2] + b[n - 1]);
            x[n - 1] = (d[n - 1] - a[n - 1] * v[n - 2]) / (a[n - 1] * u[n - 2] + b[n - 1]);

            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = u[i] * x[i + 1] + v[i];
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"x[{i+1}] = {x[i]}");
            }
            Console.ReadKey();
        }
    }
}
