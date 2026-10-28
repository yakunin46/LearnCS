using System;
namespace Num1
{
    class Program
    {
        static void Method1()
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
        }
        static void Main()
        {
            //Method1();

        }
    }
}