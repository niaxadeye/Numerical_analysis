﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        public static double Func(double x) => 1 / Math.Sqrt(5 - Math.Pow(x, 2));
        static void Main(string[] args)
        {
            double a, b;
            Console.Write("Введите число разбиений: ");
            int n = Convert.ToInt32(Console.ReadLine());
            a = 0;
            b = 1;
            double ans = 0.463647609000806;
            double s = 0;
            double h = (b - a) / n;
            for (double i = a; i < b - h; i += h)
            {
                s += 0.5 * (Func(i) + Func(i+h)) * h;
            }
            Console.WriteLine($"{s} - Ответ");
            Console.WriteLine($"{ans} - Точное значение интеграла");
            Console.WriteLine($"Точное значение интеграла - ответ =  {Math.Abs(ans - s)}");
            Console.ReadKey();
        }
    }
}
