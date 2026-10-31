using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPG
{
    /// <summary>
    /// Тип ячейки мира
    /// </summary>
    public enum Cell
    {
        /// <summary>
        /// Пустая ячейка
        /// </summary>
        EMPTY,

        /// <summary>
        /// Стена
        /// </summary>
        WALL,

        /// <summary>
        /// Игрок
        /// </summary>
        PLAYER,

        /// <summary>
        /// Предмет
        /// </summary>
        ITEM
    }

    /// <summary>
    /// Набор символов из которых состоит мир
    /// </summary>
    internal class Atlas
    {
        /// <summary>
        /// Содержит строку символов в том же порядке что и Cell
        /// </summary>
        static string str_chars = "";

        /// <summary>
        /// Задает Атлас как последовательность символов
        /// </summary>
        /// <param name="str">Строка из символов в том же порядке что и Cell</param>
        public static void Set(string str)
        {
            str_chars = str;
        }

        /// <summary>
        /// Получить символ по коду из Cell
        /// </summary>
        /// <param name="cell">Тип ячейки</param>
        /// <returns></returns>
        public static char Get(Cell cell)
        {
            return str_chars[(int) cell];
        }
    }
}