using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSh
{
    class Program
    {
        public static double Func(double x, double y) => Math.Sin((y - 1)) + x - 1.3; 
        public static double GFunc(double x, double y) => y - Math.Sin((x + 1)) - 0.8;
        public static double FuncDerivativeX(double x, double y) => 1;
        public static double FuncDerivativeY(double x, double y) => Math.Cos((y - 1));
        public static double GFuncDerivativeX(double x, double y) => - Math.Cos((x + 1));
        public static double GFuncDerivativeY(double x, double y) => 1;
        static void Main(string[] args)
        {
            Console.Write($"eps = ");
            double eps = Convert.ToDouble(Console.ReadLine());
            double x = 0;
            double y = 0;

            double D = FuncDerivativeX(x, y) * GFuncDerivativeY(x, y) - GFuncDerivativeX(x, y) * FuncDerivativeY(x, y);
            double Dx = (GFunc(x, y) * FuncDerivativeY(x, y) - Func(x, y) * GFuncDerivativeY(x, y)) / D;
            double Dy = (Func(x, y) * GFuncDerivativeX(x, y) - GFunc(x, y) * FuncDerivativeX(x, y)) / D;
            double xk = x + Dx;
            double yk = y + Dy;

            int counter = 1;

            while (Math.Abs(xk - x) > eps && Math.Abs(yk - y) > eps)
            {
                x = xk;
                y = yk;
                D = FuncDerivativeX(x, y) * GFuncDerivativeY(x, y) - GFuncDerivativeX(x, y) * FuncDerivativeY(x, y);
                Dx = (GFunc(x, y) * FuncDerivativeY(x, y) - Func(x, y) * GFuncDerivativeY(x, y)) / D;
                Dy = (Func(x, y) * GFuncDerivativeX(x, y) - GFunc(x, y) * FuncDerivativeX(x, y)) / D;
                xk = x + Dx;
                yk = y + Dy;
                counter++;
            }
            Console.WriteLine($"x = {xk} , y = {yk}, couneter = {counter}");
            Console.ReadKey();
        }
    }
}
