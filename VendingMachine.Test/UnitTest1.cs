using System;
using Xunit;

namespace VendingMachine.Test
{
    public class Vending_Machine_Test
    {
        [Fact]
        public void Insert_Money_Test()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 100;
            double amount = 10;
            double expectedBalance = 110;

            vendingMachine.InsertMoney(amount);

            Assert.Equal(expectedBalance, vendingMachine.Balance);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(101)]
        [InlineData(501)]
        [InlineData(1001)]
        [InlineData(-1)]
        public void Insert_Money_Invalid_Demonination_Test(double amount)
        {
            VendingMachine vendingMachine = new VendingMachine();

            var expectedResult = Assert.Throws<Exception>(() =>
                vendingMachine.InsertMoney(amount));

            Assert.Equal(VendingMachine.InvalidDemonination, expectedResult.Message);
        }

        [Fact]
        public void Purchase_Test()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 10;
            double expectedBalance = 8.5;

            vendingMachine.Purchase(1);

            Assert.Equal(expectedBalance, vendingMachine.Balance);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(20)]
        public void Purchase_Number_Out_Of_Range_Test(int productNumber)
        {
            VendingMachine vendingMachine = new VendingMachine();
            
            var expectedResult = Assert.Throws<IndexOutOfRangeException>(() =>
                vendingMachine.Purchase(productNumber));

            Assert.Equal(VendingMachine.InvalidProductNumber, expectedResult.Message);
        }

        [Theory]
        [InlineData(3.0, 10)]
        [InlineData(1.0, 9)]
        [InlineData(0.0, 1)]
        [InlineData(1.24, 2)]
        public void Purchase_Not_Enough_Money_Test(double balance, int productNumber)
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = balance;

            var expectedResult = Assert.Throws<Exception>(() =>
                vendingMachine.Purchase(productNumber));

            Assert.Equal(VendingMachine.NotEnoughMoney, expectedResult.Message);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(double.MaxValue)]
        [InlineData(double.MinValue)]
        public void End_Transaction_Test(double balance)
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = balance;

            double change = vendingMachine.EndTransaction();

            Assert.Equal(balance, change);
            Assert.Equal(0, vendingMachine.Balance);
        }
    }
}
