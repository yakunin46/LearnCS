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
        /// Вычисляет сумму S
        /// </summary>
        /// <param name="x">переменная x</param>
        /// <returns></returns>
        private static double CalculateS(double x)
        {
            double s = Math.Log(2);
            for (int n = 1; n <= 40; n++)
                s += Math.Cos(2 * n * x) / n;

            return s;
        }

        static void Main()
        {
            double step = (Math.PI / 2 - Math.PI / 6) / 10;
            for (double x = Math.PI / 6; x <= Math.PI / 2; x += step)
            {
                double y = CalculateY(x);
                Console.WriteLine(y);

                double s = CalculateS(x);
                Console.WriteLine(s);

                Console.WriteLine();
            }
        }
    }
}