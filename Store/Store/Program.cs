using System;
using System.Threading;
using Store.Classes;

namespace Store
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();

            Product pr1 = new Product("Яблоко", 5.50, new DateTime(2021, 6, 28));
            Product pr2 = new Product("Молоко", 26.50, new DateTime(2021, 6, 5));
            Product pr3 = new Product("Батон", 8.50, new DateTime(2021, 6, 6));
            Product pr4 = new Product("Чипсы", 22.50, new DateTime(2021, 7, 28));
            Product pr5 = new Product("Мороженное", 11.50, new DateTime(2021, 6, 10));

            Thing th1 = new Thing("Молоток", 76.75);
            Thing th2 = new Thing("Мягкая игрушка", 226.25);
            Thing th3 = new Thing("Тетрадь", 7.75);

            for (int i = 1; i < 6; i++)
            {
                Customer customer = new Customer(i);
                customer.AddItemToBuy(Item.Items[rand.Next(Item.Items.Count)], rand.Next(1, 11));
                customer.AddItemToBuy(Item.Items[rand.Next(Item.Items.Count)], rand.Next(1, 11));
                customer.AddItemToBuy(Item.Items[rand.Next(Item.Items.Count)], rand.Next(1, 11));
                customer.GoToCashRegister();
            }

            Console.ReadLine();
        }
    }
}
