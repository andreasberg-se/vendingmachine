using System;

namespace VendingMachine
{
    public abstract class Product
    {
        // Name and price of the product.
        private string name;
        private double price;

        public string Name { get {return name;} set {name = value;} }
        public double Price { get {return price;} set {price = value;} }

        // Constructor
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        // Examine: return name and price.
        public virtual string Examine()
        {
            return "Product".PadRight(10) +
                $"{Name}".PadRight(30) +
                $"€{Price:N2}";
        }

        // Use: return a message when using the product.
        public virtual string Use()
        {
            return $"Use ({Name})";
        }
    }
}
