using System;

namespace VendingMachine.Products
{
    public class Candy : Product
    {
        // Constructor
        public Candy(string name, double price) : base(name, price) {}

        // Examine: return name and price.
        public override string Examine()
        {
            return "Candy".PadRight(10) +
                $"{Name}".PadRight(30) +
                $"€{Price:N2}";
        }

        // Use: return a message when using the product.
        public override string Use()
        {
            return $"Eating candy ({Name})";
        }
    }
}
