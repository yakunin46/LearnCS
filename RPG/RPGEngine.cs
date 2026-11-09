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
        /// <summary>
        /// Список предметов мира
        /// </summary>
        List<Item> listOfItems;

        /// <summary>
        /// Список врагов
        /// </summary>
        List<Enemy> listOfEnemies;

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
            listOfEnemies = new List<Enemy>();
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

        public void AddEnemy(Enemy enemy)
        {
            listOfEnemies.Add(enemy);
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
        /// Отображает карту, игрока, врагов и предметы в консоли
        /// </summary>
        void ShowMap()
        {
            for (int i = 0; i < map.height; i++)
            {
                for (int j = 0; j < map.width; j++)
                        Console.Write(Atlas.Get(map.grid[i, j]) + " ");
                Console.WriteLine();
            }

            foreach (Enemy enemy in listOfEnemies)
            {
                Console.SetCursorPosition(2 * enemy.x, enemy.y);
                Console.Write(Atlas.Get(Cell.ENEMY));
            }

            foreach (Item item in listOfItems)
            {
                Console.SetCursorPosition(2 * item.x, item.y);
                Console.Write(Atlas.Get(Cell.ITEM));
            }

            Console.SetCursorPosition(2 * player.x, player.y);
            Console.Write(Atlas.Get(Cell.PLAYER));
        }

        /// <summary>
        /// Обрабатывает столкновение игрока с другими объектами или врагами
        /// </summary>
        private void ProcessCollisions()
        {
            List<Item> newList = new List<Item>();
            foreach (Item item in listOfItems)
            {
                if (player.x == item.x && player.y == item.y)
                    player.AddItem(item);
                else
                    newList.Add(item);
            }
            List<Enemy> newList1 = new List<Enemy>();
            foreach (Enemy enemy in listOfEnemies)
            {
                if (player.x == enemy.x && player.y == enemy.y)
                    enemy.Attack(player.attack);
                if (enemy.hp > 0)
                    newList1.Add(enemy);
            }

            listOfItems = newList;
            listOfEnemies = newList1;
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
                ProcessCollisions();

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