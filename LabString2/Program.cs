using System;

namespace LabString2
{
    class Program
    {
        /// <summary>
        /// Определяет целое неотрицательное число
        /// по его строковому представлению S в 3-ричной системе счисления
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        private static int ToDec(string S)
        {
            int number = 0;
            int threeLevel = 1;
            for (int i = S.Length - 1; i >= 0; i--)
            {
                number += (S[i] - '0') * threeLevel;
                threeLevel *= 3;
            }
            return number;
        }

        static void Main()
        {
            int number;

            number = ToDec("2011");
            Console.WriteLine(number);

            number = ToDec("10220");
            Console.WriteLine(number);

            number = ToDec("0");
            Console.WriteLine(number);

            number = ToDec("120");
            Console.WriteLine(number);

            number = ToDec("0010");
            Console.WriteLine(number);
        }
    }
}
