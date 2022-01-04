using System;
using System.Collections.Generic;
using VendingMachine.Products;

namespace VendingMachine
{
    public class VendingMachine : IVending
    {
        // Constants
        public const string InvalidProductIndex = "Invalid product index!";
        public const string NotEnoughMoney = "Not enough money to purchase this product!";
        public const string InvalidDemonination = "Invalid demonination!";

        // Balance: money inserted.
        public double Balance { get; set; }

        // Demoninations
        private readonly int[] moneyDemoninations = {1, 5, 10, 20, 50, 100, 500, 1000};

        // Products in the machine.
        public List<Product> products;

        // Constructor
        public VendingMachine()
        {
            this.Balance = 0.0;

            products = new List<Product>()
            {
                new Snacks("Potato Chips", 1.5),
                new Snacks("Cheese Curls", 1.25),
                new Snacks("Peanuts", 1),
                new Candy("Chocolate Bar", 2),
                new Candy("Cookie", 1),
                new Soda("Cola", 1.5),
                new Soda("Lemon/Lime Soda", 1.5),
                new Soda("Raspberry Soda", 1.5),
                new Toy("Airplane", 5),
                new Toy("Car", 3.5)
            };
        }

        // Purchase product.
        public void Purchase(int productIndex)
        {
            if ((productIndex < 0) || (productIndex >= products.Count))
            {
                throw new IndexOutOfRangeException(InvalidProductIndex);
            }
            if (Balance < products[productIndex].Price)
            {
                throw new Exception(NotEnoughMoney);
            }
            Balance -= products[productIndex].Price;
        }

        // Returns all the products as a list.
        public List<string> ShowAll()
        {
            List<string> productList = new List<string>();
            int index = 1;
            foreach (Product product in products)
            {
                productList.Add("[ " + $"{index++}".PadLeft(2) + " ]  " +
                    product.Examine());
            }
            return productList;
        }

        // Insert money.
        public void InsertMoney(double amount)
        {
            bool valid = false;
            for (int i = 0; i < moneyDemoninations.Length; i++)
            {
                if (amount == moneyDemoninations[i])
                {
                    valid = true;
                    break;
                }
            }
            if (!valid)
            {
                throw new Exception(InvalidDemonination);
            }
            this.Balance += amount;
        }

        // End transaction and return the change.
        public double EndTransaction()
        {
            double change = this.Balance;
            this.Balance = 0.0;
            return change;
        }

    }
}
