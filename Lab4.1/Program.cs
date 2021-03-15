using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._1
{
    class Program
    {
        public static double Func(double x, double y) => Math.Sin((y - 1)) + x - 1.3;
        public static double GFunc(double x, double y) => y - Math.Sin((x + 1)) - 0.8;
        public static double FuncDerivativeX() => 1;
        public static double FuncDerivativeY(double y) => Math.Cos((y - 1));
        public static double GFuncDerivativeX(double x) => -Math.Cos((x + 1));
        public static double GFuncDerivativeY() => 1;
        static void Main(string[] args)
        {
            Console.Write($"eps = ");
            double eps = Convert.ToDouble(Console.ReadLine());
            double x = 0;
            double y = 0;

            double D = FuncDerivativeX() * GFuncDerivativeY() - GFuncDerivativeX(x) * FuncDerivativeY(y);
            double Dx = (GFunc(x, y) * FuncDerivativeY(y) - Func(x, y) * GFuncDerivativeY()) / D;
            double Dy = (Func(x, y) * GFuncDerivativeX(y) - GFunc(x, y) * FuncDerivativeX()) / D;
            double xk = x + Dx;
            double yk = y + Dy;

            int counter = 1;

            while (Math.Abs(xk - x) > eps && Math.Abs(yk - y) > eps)
            {
                x = xk;
                y = yk;
                D = FuncDerivativeX() * GFuncDerivativeY() - GFuncDerivativeX(x) * FuncDerivativeY(y);
                Dx = (GFunc(x, y) * FuncDerivativeY(y) - Func(x, y) * GFuncDerivativeY()) / D;
                Dy = (Func(x, y) * GFuncDerivativeX(y) - GFunc(x, y) * FuncDerivativeX()) / D;
                xk = x + Dx;
                yk = y + Dy;
                counter++;
            }
            Console.WriteLine($"x = {xk} , y = {yk}, couneter = {counter}");
            Console.ReadKey();
        }
    }
}
