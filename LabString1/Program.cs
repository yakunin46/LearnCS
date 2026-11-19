using System;

namespace Lab7_2
{
    class Program
    {
        /// <summary>
        /// Создает массив, содержащий строчные латинские буквы
        /// </summary>
        /// <returns></returns>
        private static char[] CreateCharMas()
        {
            char[] symbols = new char[26];

            for (int i = 0; i < 26; i++)
                symbols[i] = (char)('\u0061' + i);

            return symbols;
        }

        /// <summary>
        /// Генерирует строку по условию задачи
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        private static string GenerateString(char[] symbols)
        {
            string str = "";
            Random r = new Random();
            int countOfWords = r.Next(1, 41);
            for (int i = 0; i < countOfWords; i++)
            {
                int countOfLetters = r.Next(2, 8);
                string strRandom = "";
                for (int j = 0; j < countOfLetters; j++)
                {
                    int index = r.Next(0, 26);
                    strRandom += symbols[index];
                }
                str += strRandom;
                if (i != countOfWords - 1)
                {
                    int countOfSpace = r.Next(1, 5);
                    for (int k = 0; k < countOfSpace; k++)
                        str += " ";
                }
            }
            str += ".";
            return str;
        }

        /// <summary>
        /// Разбивает строку на массив слов по пробелам и точке
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string[] SplitString(string str)
        {
            string[] str1 = str.Split(' ', '.');
            int countOfEmpty = 0;

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] == "")
                    countOfEmpty++;

            string[] str2 = new string[str1.Length - countOfEmpty];

            for (int i = 0, j = 0; i < str2.Length; j++)
                if (str1[j] != "")
                {
                    str2[i] = str1[j];
                    i++;
                }

            return str2;
        }
        static void Main()
        {
            char[] symbols = CreateCharMas();
            string str = GenerateString(symbols);
            Console.WriteLine(str);

            string[] masStr = SplitString(str);

            foreach (string element in masStr)
                if ((element != masStr[0]) && (element.Length <= 5))
                    Console.WriteLine(element);
        }
    }
}
