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
        public World world;

        /// <summary>
        /// Экземпляр игрока
        /// </summary>
        public Player player;

        /// <summary>
        /// Создает игровой движок
        /// </summary>
        /// <param name="width">Ширина мира</param>
        /// <param name="height">Высота мира</param>
        public RPG_Engine(int width, int height)
        {
            world = new World(width, height);
            player = new Player(width / 2, height / 2);
            world.grid[player.y, player.x] = Cell.PLAYER;
        }

        /// <summary>
        /// Меняет позицию игрока в мире
        /// </summary>
        /// <param name="x">Новое положение игрока по оси X</param>
        /// <param name="y">Новое положение игрока по оси Y</param>
        public void SetPlayer(int x, int y)
        {
            world.grid[player.y, player.x] = Cell.EMPTY;
            player.x = x; player.y = y;
            world.grid[player.y, player.x] = Cell.PLAYER;
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

                world.Show();

                Console.Write("1.Влево\n2.Вправо\n3.Вверх\n4.Вниз\n>");

                inputKey = Console.ReadKey();

                if (inputKey.KeyChar == '1' && player.x > 1)
                    SetPlayer(player.x - 1, player.y);

                if (inputKey.KeyChar == '2' && player.x < world.width - 2)
                    SetPlayer(player.x + 1, player.y);

                if (inputKey.KeyChar == '3' && player.y > 1)
                    SetPlayer(player.x, player.y - 1);

                if (inputKey.KeyChar == '4' && player.y < world.height - 2)
                    SetPlayer(player.x, player.y + 1);
            }
        }
    }
}