using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using Console = Colorful.Console;

namespace Num1
{
    class Program
    {
        static void Method1()
        {
            int[] mas = [1, 2, 3, 4];
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine("\nconsole in pink", Color.Green);
            Console.WriteLine("console in default");
            Console.WriteAscii("NARUTO", Color.Orange);
            Console.WriteAscii("SASUKE", Color.Orchid);

            int r = 225;
            int g = 255;
            int b = 250;

            List<string> storyFragment = new List<string>()
            {
                "Том не пошел в школу и отлично провел время.",
                "Он еле успел вернуться домой, чтобы до ужина помочь негритенку Джиму",
                "напилить на завтра дров и наколоть щепок для растопки.",
                "Во всяком случае, он успел рассказать Джиму о своих похождениях,",
                "пока тот сделал три четверти работы.",
                "Младший (или, скорее, сводный) брат Тома, Сид, уже сделал все, что ему полагалось",
                "(он подбирал и носил щепки): это был послушный мальчик,",
                "не склонный к шалостям и проказам."
            };

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(storyFragment[i], Color.FromArgb(r, g, b));

                r -= 18;
                b -= 9;
            }
        }

        static void Method2()
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello to c#!");

            Console.WriteLine(true);
            Console.WriteLine(false);

            Console.WriteLine(0b11);        // 3
            Console.WriteLine(0b1011);      // 11
            Console.WriteLine(0b100001);    // 33

            Console.WriteLine(0x0A);    // 10
            Console.WriteLine(0xFF);    // 255
            Console.WriteLine(0xA1);    // 161

            Console.WriteLine('\x78');    // x
            Console.WriteLine('\x5A');    // Z

            Console.WriteLine('\u0420');    // Р
            Console.WriteLine('\u0421');    // С

            Console.WriteLine("Привет\nмир\n");

            Console.Write("Введите свое имя: ");
            string? name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}");

            Console.Write("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Возраст: {age}");

            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 1, 2 };
            numbers[1] = new int[] { 1, 2, 3 };
            numbers[2] = new int[] { 1, 2, 3, 4, 5 };
            foreach (int[] row in numbers)
            {
                foreach (int number in row)
                    Console.Write($"{number} \t");
                Console.WriteLine();
            }
        }

        static void Method3()
        {
            int max = 5 > 2 ? 5 : 2;
            Console.WriteLine(max);

            int[] mas = { -4, 21, 56, -9, 0, -23, 12, 9, -6 };

            foreach (int i in mas)
            {
                Console.Write(i + "\t");
            }

            for (int i = 0; i < mas.Length / 2; i++)
            {
                int temp = mas[i];
                mas[i] = mas[mas.Length - 1 - i];
                mas[mas.Length - 1 - i] = temp;
            }

            Console.WriteLine();

            foreach (int i in mas)
                Console.Write(i + "\t");

            for (int i = 0; i < mas.Length - 1; i++)
                for (int j = i + 1; j < mas.Length; j++)
                    if (mas[i] > mas[j])
                    {
                        int temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }

            Console.WriteLine();

            foreach (int i in mas)
            {
                Console.Write(i + "\t");
            }
        }

        static void Method4()
        {
            BankAccount account1 = new BankAccount("Alex", 1200.6891M);
            BankAccount account2 = new BankAccount("Alice", 35012);
            BankAccount account3 = new BankAccount("Mark", 305.4M);

            account1.GetInfo();
            Console.WriteLine();

            account2.GetInfo();
            Console.WriteLine();

            account3.GetInfo();
            Console.WriteLine();

            account1.Deposit(-500);
            Console.WriteLine();

            account1.Deposit(720);
            Console.WriteLine();

            account2.Withdraw(40000);
            Console.WriteLine();

            account2.Withdraw(10000);
            Console.WriteLine();
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Method1();
            //Method2();
            //Method3();
            Method4();
            List<Product> list = new List<Product>();
            list.Add(new Product("Книга", "Книжная продукция", 300, 15));
            list.Add(new Product("Ручка", "Канелярия", 35, 200));
            list.Add(new Product("Карандаш", "Канелярия", 15, 400));
            list.Add(new Product("Принтер", "Цифровая техника", 12000, 14));
            list.Add(new Product("Линейка", "Канелярия", 45, 72));
            list.Add(new Product("Футболка", "Одежда", 1200, 80));
            list.Add(new Product("Ботинки", "Обувь", 3400, 35));
            list.Add(new Product("Кофта", "Одежда", 2500, 50));
            list.Add(new Product("Журнал", "Книжная продукция", 180, 40));
            list.Add(new Product("Зеркало", "Декор", 15000, 8));
            list.Add(new Product("Ваза", "Декор", 3500, 42));
        }
    }
}