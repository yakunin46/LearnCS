using System;

namespace RPG
{
    class Program
    {
        const int Height = 4;
        const int Width = 4;
        static int[,] mas = new int[Height, Width];
        static List<Item> listOfItems = new List<Item>();
        static void FillMas()
        {
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    mas[i, j] = i + 1;
        }
        static void ShowMas()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write($"{mas[i,j]} ");
                Console.WriteLine();
            }
        }
        static void ShowListOfItems()
        {
            foreach(Item item in listOfItems)
                Console.WriteLine(item.GetName());
        }
        public static void Main()
        {
            FillMas();
            ShowMas();

            listOfItems.Add(new Item("Меч"));
            listOfItems.Add(new Item("Щит"));
            listOfItems.Add(new Item("Шлем"));
            listOfItems.Add(new Item("Сапоги"));
            listOfItems.Add(new Item("Кольчуга"));
            listOfItems.Add(new Item("Перчатки"));

            ShowListOfItems();

            Atlas.Set(" #$");

            RPG_Engine engine = new RPG_Engine();
            engine.SetMap(new Map(30, 20));
            engine.SetPlayer(10, 2);

            //engine.SetMap(new Map(10, 20));
            //engine.SetPlayer(5, 5);

            engine.Run();
        }
    }
}