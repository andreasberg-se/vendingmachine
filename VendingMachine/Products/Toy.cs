using System;

namespace VendingMachine.Products
{
    public class Toy : Product
    {
        // Constructor
        public Toy(string name, double price) : base(name, price) {}

        // Examine: return name and price.
        public override string Examine()
        {
            return "Toy".PadRight(10) +
                $"{Name}".PadRight(30) +
                $"€{Price:N2}";
        }

        // Use: return a message when using the product.
        public override string Use()
        {
            return $"Play with toy ({Name})";
        }
    }
}
