using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    /// <summary>
    /// Игровой предмет
    /// </summary>
    internal class Item
    {

        /// <summary>
        /// Название предмета
        /// </summary>
        public string name;

        /// <summary>
        /// Создает предмет
        /// </summary>
        /// <param name="name">Имя предмета</param>
        public Item(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Выводит название предмеета в консоль
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }
    }
}
