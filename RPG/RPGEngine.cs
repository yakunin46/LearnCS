using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    /// <summary>
    /// Игровой движок
    /// </summary>
    internal class RPGEngine
    {
        List<Item> listOfItems;
        /// <summary>
        /// Экземпляр карты
        /// </summary>
        Map map;

        /// <summary>
        /// Экземпляр игрока
        /// </summary>
        Player player;

        /// <summary>
        /// Создает игровой движок
        /// </summary>
        public RPGEngine()
        {
            map = new Map(2, 2);
            player = new Player(1, 1);
            listOfItems = new List<Item>();
        }

        /// <summary>
        /// Меняет карту
        /// </summary>
        /// <param name="map"></param>
        public void SetMap(Map map)
        {
            this.map = map;
            listOfItems.Clear();
        }

        /// <summary>
        /// Меняет позицию игрока на карте
        /// </summary>
        /// <param name="x">Новое положение игрока по оси X</param>
        /// <param name="y">Новое положение игрока по оси Y</param>
        public void SetPlayer(int x, int y)
        {
            player.x = x;
            player.y = y;
        }

        /// <summary>
        /// Устанавливает положение предмета на карте
        /// </summary>
        /// <param name="item"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddItem(Item item, int x, int y)
        {
            item.x = x;
            item.y = y;
            listOfItems.Add(item);
        }
        /// <summary>
        /// Проверяет нажатую клавишу
        /// </summary>
        /// <param name="inputKey">Информация о нажатой клавише</param>
        void CheckKey(ConsoleKeyInfo inputKey)
        {
            if (inputKey.KeyChar == '1' && player.x > 1)
                SetPlayer(player.x - 1, player.y);

            if (inputKey.KeyChar == '2' && player.x < map.width - 2)
                SetPlayer(player.x + 1, player.y);

            if (inputKey.KeyChar == '3' && player.y > 1)
                SetPlayer(player.x, player.y - 1);

            if (inputKey.KeyChar == '4' && player.y < map.height - 2)
                SetPlayer(player.x, player.y + 1);
        }

        /// <summary>
        /// Отображает карту, игрока и предметы в консоли
        /// </summary>
        void ShowMap()
        {
            for (int i = 0; i < map.height; i++)
            {
                for (int j = 0; j < map.width; j++)
                        Console.Write(Atlas.Get(map.grid[i, j]) + " ");
                Console.WriteLine();
            }

            foreach (Item item in listOfItems)
            {
                Console.SetCursorPosition(2 * item.x, item.y);
                Console.Write(Atlas.Get(Cell.ITEM));
                if (player.x == item.x && player.y == item.y)
                    player.AddItem(item);
            }

            Console.SetCursorPosition(2 * player.x, player.y);
            Console.Write(Atlas.Get(Cell.PLAYER));
        }

        /// <summary>
        /// Запускает игру
        /// </summary>
        public void Run()
        {
            ConsoleKeyInfo inputKey;
            Console.Clear();
            Console.CursorVisible = false;

            while (true) 
            {
                Console.SetCursorPosition(0, 0);
                ShowMap();

                Console.SetCursorPosition(0, map.height);
                Console.Write("1.Влево\n2.Вправо\n3.Вверх\n4.Вниз\n>\n");
                player.PrintInventory();

                Console.SetCursorPosition(1, map.height + 4);
                inputKey = Console.ReadKey();
                CheckKey(inputKey);
            }
        }
    }
}