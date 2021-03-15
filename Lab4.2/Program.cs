using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._2
{
    class Program
    {
        public static double Func(double y) => - Math.Sin((y - 1)) + 1.3;
        public static double GFunc(double x) => Math.Sin((x + 1)) + 0.8;
        static void Main(string[] args)
        {
            Console.Write($"eps = ");
            double eps = Convert.ToDouble(Console.ReadLine());
            double x, x0 = 0;
            double y, y0 = 0;
            x = Func(y0);
            y = GFunc(x0);

            int counter = 1;
            while (Math.Abs(x - x0) > eps || Math.Abs(y - y0) > eps)
            {
                counter++;
                x0 = x;
                y0 = y;
                x = Func(y0);
                y = GFunc(x0);
            }
            Console.WriteLine($"x = {x} , y = {y}, couneter = {counter}");
            Console.ReadKey();
        }
    }
}
