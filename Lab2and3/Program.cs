using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2and3
{
    class Program
    {
        public static double Func(double x) => Math.Log10(1 + 2 * x) - 2 + x;
        public static double FuncFirstDerivative(double x) => 1 + 2 / (2 * x + 1);
        public static double FuncSecondDerivative(double x) => -4 / ((2 * x + 1) * (2 * x + 1));
        public static double FuncFi(double x) => 2 - Math.Log10(1 + 2 * x);
        public static void Dichotomy(double a, double b, double eps)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("\nМетод дихотомии");
            double c = (a + b) / 2;
            int counter = 0;
            if (Func(a) * Func(c) < 0) b = c; else a = c;
            c = (a + b) / 2;

            stopwatch.Start();
            while (Math.Abs(a - c) > eps)
            {
                if (Func(a) * Func(c) < 0) b = c; else a = c;
                c = (a + b) / 2;
                counter++;
            }
            stopwatch.Stop();

            Console.WriteLine($"x = {a}");
            Console.WriteLine($"counter = {counter}");
            Console.WriteLine($"Время выполнения = {stopwatch.Elapsed.TotalMilliseconds} ms");
        }

        public static void Newton(double a, double eps)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("\nМетод Ньютона");
            double x = a;
            int counter = 0;

            stopwatch.Start();
            while (Math.Abs(Func(x) / FuncFirstDerivative(x)) > eps)
            {
                x = x - Func(x) / FuncFirstDerivative(x);
                counter++;
            }
            stopwatch.Stop();

            Console.WriteLine($"x = {x}");
            Console.WriteLine($"counter = {counter}");
            Console.WriteLine($"Время выполнения = {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        public static void SimpleIter(double a, double eps)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("\nМетод Простых итераций");
            double prev;

            stopwatch.Start();
            double x = FuncFi(a);
            prev = x;
            x = FuncFi(prev);
            int counter = 2;
            while (Math.Abs(x - prev) > eps)
            {
                counter++;
                prev = x;
                x = FuncFi(prev);
            }
            stopwatch.Stop();
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"counter = {counter}");
            Console.WriteLine($"Время выполнения = {stopwatch.Elapsed.TotalMilliseconds} ms");

        }
        public static void Hord(double a, double b, double eps)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("\nМетод Хорд");
            double c;
            int counter = 0;
            stopwatch.Start();
            c = a - ((b - a) / (Func(b) - Func(a))) * Func(a);
            if (Func(a) * Func(c) > 0) a = c; else b = c;
            while (Math.Abs(b - a) > eps)
            {
                counter++;
                c = a - ((b - a) / (Func(b) - Func(a))) * Func(a);
                if (Func(a) * Func(c) > 0) a = c; else b = c;
                Console.WriteLine($"a = {a} b = {b}");
            }
            double x = (a + b) / 2;
            stopwatch.Stop();
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"counter = {counter}");
            Console.WriteLine($"Время выполнения = {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        public static void HordNew(double a, double b, double eps)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("\nМетод Хорд New");
            int counter = 0;
            double prev;
            double x0 = b;
            double x = a;
            stopwatch.Start();
            do
            {
                prev = x;
                x = prev - (Func(prev) * (prev - x0)) / (Func(prev) - Func(x0));
                counter++;
            } while (Math.Abs(x - prev) > eps);
            stopwatch.Stop();
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"counter = {counter}");
            Console.WriteLine($"Время выполнения = {stopwatch.Elapsed.TotalMilliseconds} ms");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите интервал (a,b)");

            Console.Write("a = ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("b = ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите желаемую точность");

            Console.Write("eps = ");
            double eps = Convert.ToDouble(Console.ReadLine()); ;

            Dichotomy(a, b, eps);
            Newton(a, eps); //a - начальное приближение
            SimpleIter(a, eps); //a - начальное приближение
            HordNew(a, b, eps);
            Console.ReadKey();


        }
    }
}
