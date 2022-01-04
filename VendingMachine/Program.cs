using System;
using System.Collections.Generic;
using static System.Console;

namespace VendingMachine
{
    class Program
    {
        // Constants
        private const string PressAnyKey = "\nPress any key to continue ...";

        // Write List.
        static void WriteList(List<string> list)
        {
            foreach (string item in list)
            {
                WriteLine(item);
            }
        }



        // Main method.
        static void Main(string[] args)
        {
            // Create an instance of the vending machine.
            VendingMachine vendingMachine = new VendingMachine();

            // Main loop.
            bool isRunning = true;
            while (isRunning)
            {
                // Show menu and balance.
                Clear();
                Write("Vending Machine\n" +
                    "---------------\n" +
                    "[ i ] Insert money                      [ p ] Purchase product\n" +
                    "[ s ] Show products                     [ e ] End transaction\n" +
                    "\n[ q ] Quit\n" +
                    $"\nBalance: €{vendingMachine.Balance:N2}\n\n" +
                    "Select: ");

                // Prompt user to make a selection.
                string menuSelection = ReadLine().Trim();
                WriteLine();

                // Handle menu selection.
                switch (menuSelection.ToLower())
                {
                    case "q":
                        // Quit
                        isRunning = false;
                        break;

                    case "i":
                        // Insert money
                        Console.Write("Enter amount: ");
                        double amount;
                        if (double.TryParse(ReadLine().Trim(), out amount))
                        {
                            WriteLine();
                            try
                            {
                                vendingMachine.InsertMoney(amount);
                            }
                            catch (Exception exception)
                            {
                                WriteLine(exception.Message);
                                Console.Write(PressAnyKey);
                                ReadKey();
                            }
                        }
                        break;

                    case "p":
                        // Purchase
                        Console.Write($"Enter product number (1-{vendingMachine.products.Count}): ");
                        int productNumber;
                        if (int.TryParse(ReadLine().Trim(), out productNumber))
                        {
                            WriteLine();
                            try
                            {
                                vendingMachine.Purchase(productNumber);
                                int productIndex = productNumber-1;
                                Write(vendingMachine.products[productIndex].Use());
                                ReadKey();
                            }
                            catch (IndexOutOfRangeException exception)
                            {
                                WriteLine(exception.Message);
                                Console.Write(PressAnyKey);
                                ReadKey();
                            }
                            catch (Exception exception)
                            {
                                WriteLine(exception.Message);
                                Console.Write(PressAnyKey);
                                ReadKey();
                            }
                        }
                        break;

                    case "s":
                        // Show products
                        WriteList(vendingMachine.ShowAll());
                        Console.Write(PressAnyKey);
                        ReadKey();
                        break;

                    case "e":
                        // End transaction
                        Console.Write($"€{vendingMachine.EndTransaction():N2} returned!");
                        ReadKey();
                        break;

                    default:
                        // Invalid choice
                        if (menuSelection != "")
                        {
                            Write($"Error: Invalid choice '{menuSelection}'!");
                            ReadKey();
                        }
                        break;
                }
            }
        }
    }
}
