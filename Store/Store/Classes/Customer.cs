using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Store.Classes
{
    public class Customer
    {
        public Dictionary<Item, int> ToBuy = new Dictionary<Item, int>();

        static Semaphore sem = new Semaphore(3, 3);
        Thread customerThread;
        int count = 3;

        public Customer(int i)
        {
            customerThread = new Thread(Buy);
            customerThread.Name = $"Покупатель {i.ToString()}";
        }

        public void AddItemToBuy(Item item, int amount)
        {
            if (ToBuy != null && ToBuy.ContainsKey(item))
                ToBuy[item] += amount;
            else
                ToBuy.Add(item, amount);
        }

        public double CalculateCheck()
        {
            double toPay = 0;
            foreach (Item item in ToBuy.Keys)
            {
                Console.WriteLine($"\t{item} - {ToBuy[item]}шт ({Thread.CurrentThread.Name})");
                toPay += item.CalculateCost(ToBuy[item]);
            }
            return toPay;
        }

        public void GoToCashRegister()
        {
            customerThread.Start();
        }

        public void Buy()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} идёт на кассу, чтобы купить:");

                double paid = CalculateCheck();
                Console.WriteLine($"{Thread.CurrentThread.Name} расплачивается, сумма: {paid}");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает магазин");

                sem.Release();

                count--;
                Thread.Sleep(1000);
            }
        }

    }
}
