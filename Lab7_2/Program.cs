using System;

namespace Lab7_2
{
    class Program
    {
        /// <summary>
        /// Вычисляет значение функции Y
        /// </summary>
        /// <param name="x">переменная x</param>
        /// <returns></returns>
        private static double CalculateY(double x)
        {
            return -Math.Log(Math.Abs(Math.Sin(x))) + 0.0;
        }

        /// <summary>
        /// Вычисляет сумму S, используя рекурсию
        /// </summary>
        /// <param name="x">переменная x</param>
        /// <returns></returns>
        private static double CalculateS(double x, int n)
        {
            if (n == 0)
                return Math.Log(2);
            else
                return CalculateS(x, n - 1) + Math.Cos(2 * n * x) / n;
        }

        static void Main()
        {
            double step = (Math.PI / 2 - Math.PI / 6) / 10;
            for (double x = Math.PI / 6; x <= Math.PI / 2; x += step)
            {
                double y = CalculateY(x);
                Console.WriteLine(y);

                double s = CalculateS(x, 40);
                Console.WriteLine(s);

                Console.WriteLine();
            }
        }
    }
}