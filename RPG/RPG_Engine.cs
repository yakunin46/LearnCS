using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    /// <summary>
    /// Игровой движок
    /// </summary>
    internal class RPG_Engine
    {
        /// <summary>
        /// Экземпляр мира
        /// </summary>
        public Map map;

        /// <summary>
        /// Экземпляр игрока
        /// </summary>
        public Player player;

        /// <summary>
        /// Создает игровой движок
        /// </summary>
        /// <param name="width">Ширина мира</param>
        /// <param name="height">Высота мира</param>
        public RPG_Engine()
        {
            player = new Player(1, 1);
        }

        public void SetMap(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Меняет позицию игрока в мире
        /// </summary>
        /// <param name="x">Новое положение игрока по оси X</param>
        /// <param name="y">Новое положение игрока по оси Y</param>
        public void SetPlayer(int x, int y)
        {
            player.x = x; 
            player.y = y;
        }

        /// <summary>
        /// Проверяет нажатую клавишу
        /// </summary>
        /// <param name="inputKey">Информация о нажатой клавише</param>
        public void CheckKey(ConsoleKeyInfo inputKey)
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

        public void Show()
        {
            for (int i = 0; i < map.height; i++)
            {
                for (int j = 0; j < map.width; j++)
                {
                    if (i == player.y && j == player.x)
                        Console.Write(Atlas.Get(Cell.PLAYER) + " ");
                    else if (map.grid[i, j] == Cell.WALL)
                        Console.Write(Atlas.Get(Cell.WALL) + " ");
                    else if (map.grid[i, j] == Cell.EMPTY)
                        Console.Write(Atlas.Get(Cell.EMPTY) + " ");

                }
                Console.WriteLine();
            }
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
                Show();

                Console.SetCursorPosition(0, map.height);
                Console.Write("1.Влево\n2.Вправо\n3.Вверх\n4.Вниз\n>");

                inputKey = Console.ReadKey();
                CheckKey(inputKey);
            }
        }
    }
}