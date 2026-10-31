using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RPG
{
    /// <summary>
    /// Игрок
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// Положение игрока по оси абсцис
        /// </summary>
        public int x;

        /// <summary>
        /// Положение игрока по оси ординат
        /// </summary>
        public int y;

        /// <summary>
        /// Создает игрока
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}