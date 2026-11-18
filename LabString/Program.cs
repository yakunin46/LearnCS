using System;

namespace LabString
{
    class Program
    {
        private static char[] CreateCharMas()
        {
            char[] symbols = new char[26];

            for (int i = 0; i < 26; i++)
                symbols[i] = (char)('\u0061' + i);

            return symbols;
        }

        private static string FillString(string str, char[] symbols)
        {
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
        static void Main()
        {
            string str = "";
            char[] symbols = CreateCharMas();
            str = FillString(str, symbols);
            Console.WriteLine(str);

            string[] str1 = str.Split(' ');
            int count = 0;

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] == "")
                    count++;

            string[] str2 = new string[str1.Length - count];

            for (int i = 0, j = 0; i < str2.Length; i++, j++)
                if (str1[j] != "")
                    str2[i] = str1[j];
                else
                    i--;

            foreach (string element in str2)
                if ((element != str2[0]) && (element.Length <= 5))
                    Console.WriteLine(element);

            //Console.ReadKey();
        }
    }
}
