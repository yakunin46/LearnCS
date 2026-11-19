using System;
using System.Collections.Generic;
using System.Text;

namespace Num1
{
    internal class Product
    {
        public int ID {  get; set; }
        private static int productCounter = 0;
        public string Name { get; set; } = "Product";
        public string Category { get; set; } = "Category";
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public Product(string name, string category, decimal price, int stock)
        {
            ID = ++productCounter;
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
        }
    }
}