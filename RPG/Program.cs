using System;

namespace RPG
{
    /// <summary>
    /// Задание: добавить метод SetItem()
    /// </summary>
    class Program
    {
        public static void Main()
        {
            Atlas.Set(" #$?");

            RPGEngine engine = new RPGEngine();
            engine.SetMap(new Map(30, 20));
            engine.SetPlayer(10, 2);
            engine.AddItem(new Item("Бочка"), 2, 2);
            engine.AddItem(new Item("Камень"), 5, 8);
            engine.AddItem(new Item("Бревно"), 22, 12);
            engine.AddItem(new Item("Меч"), 13, 17);

            //engine.SetMap(new Map(10, 20));
            //engine.SetPlayer(5, 5);

            engine.Run();
        }
    }
}