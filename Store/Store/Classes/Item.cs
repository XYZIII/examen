using System;
using System.Collections.Generic;

namespace Store.Classes
{
    public abstract class Item
    {
        public static List<Item> Items = new List<Item>();
        string Name { get; set; }

        private double price;
        public double Price { get { return price; } set { price = value; }}

        public Item()
        {
        }

        public Item(string name, double price)
        {
            Name = name;
            this.price = price;
            Items.Add(this);
        }

        public double CalculateCost(double amount)
        {
            return amount * price;
        }

        public double CalculateCost(double amount, double sale)
        {
            return amount * price * sale;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
