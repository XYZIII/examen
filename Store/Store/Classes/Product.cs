using System;
namespace Store.Classes
{
    public class Product : Item
    {

        private DateTime expiresOn;
        public DateTime ExpiresOn { get { return expiresOn; } set { expiresOn = value; }}

        public Product()
        {
        }

        public Product(string name, double price, DateTime expires) : base(name, price)
        {
            this.expiresOn = expires;
        }

        public bool IsExpired()
        {
            return DateTime.Today > expiresOn;
        }
    }
}
