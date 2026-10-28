using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace RPG
{
    /// <summary>
    /// Игровой мир
    /// </summary>
    internal class World
    {
        /// <summary>
        /// Ширина мира
        /// </summary>
        public int width;

        /// <summary>
        /// Высота мира
        /// </summary>
        public int height;

        /// <summary>
        /// Создает сетку мира
        /// </summary>
        public Cell[,] grid;

        /// <summary>
        /// Создает мир
        /// </summary>
        /// <param name="height">Высота мира</param>
        /// <param name="width">Ширина мира</param>
        public World(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new Cell[height, width];
            Create();
        }

        /// <summary>
        /// Заполняет границы мира как стенки
        /// </summary>        
        public void Create()
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                        grid[i, j] = Cell.WALL;
                    else
                        grid[i, j] = Cell.EMPTY;
        }

        /// <summary>
        /// Выводит мир в консоль
        /// </summary>
        public void Show()
        {
            char c1 = Atlas.Get(Cell.WALL);
            char c2 = Atlas.Get(Cell.EMPTY);
            char c3 = Atlas.Get(Cell.PLAYER);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (grid[i, j] == Cell.WALL)
                        Console.Write(c1 + " ");
                    if (grid[i, j] == Cell.EMPTY)
                        Console.Write(c2 + " ");
                    if (grid[i, j] == Cell.PLAYER)
                        Console.Write(c3 + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
