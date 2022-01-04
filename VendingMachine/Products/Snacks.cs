using System;

namespace VendingMachine.Products
{
    public class Snacks : Product
    {
        // Constructor
        public Snacks(string name, double price) : base(name, price) {}

        // Examine: return name and price.
        public override string Examine()
        {
            return "Snacks".PadRight(10) +
                $"{Name}".PadRight(30) +
                $"€{Price:N2}";
        }

        // Use: return a message when using the product.
        public override string Use()
        {
            return $"Eating snacks ({Name})";
        }
    }
}
