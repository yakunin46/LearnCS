using System;

namespace Lab7_1
{
    class Program
    {
        /// <summary>
        /// Считает количество простых чисел в массиве
        /// </summary>
        /// <param name="a">массив целых чисел</param>
        /// <param name="n">количество элементов в массиве</param>
        /// <returns></returns>
        private static int pros_elem(int[] a, int n)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                bool flag = true;
                for (int j = 2; j < a[i] / 2 + 1; j++)
                    if (a[i] % j == 0)
                        flag = false;
                if (flag == true)
                    count++;
            }

            return count;
        }

        static void Main()
        {
            int[] b = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            int count = pros_elem(b, b.Length);
            Console.WriteLine(count);
        }
    }
}