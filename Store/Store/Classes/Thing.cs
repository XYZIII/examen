using System;
namespace Store.Classes
{
    public class Thing : Item
    {
        public Thing()
        {
        }

        public Thing(string name, double price) : base(name, price)
        {
        }
    }
}
