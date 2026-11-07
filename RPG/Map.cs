using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace RPG
{
    /// <summary>
    /// Игровая карта
    /// </summary>
    internal class Map
    {
        /// <summary>
        /// Ширина карты
        /// </summary>
        public int width;

        /// <summary>
        /// Высота карты
        /// </summary>
        public int height;

        /// <summary>
        /// Создает сетку карты
        /// </summary>
        public Cell[,] grid;

        /// <summary>
        /// Создает карту
        /// </summary>
        /// <param name="height">Высота мира</param>
        /// <param name="width">Ширина мира</param>
        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new Cell[height, width];
            Create();
        }

        /// <summary>
        /// Заполняет границы карты как стенки
        /// </summary>        
        void Create()
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                        grid[i, j] = Cell.WALL;
                    else
                        grid[i, j] = Cell.EMPTY;
        }
    }
}
