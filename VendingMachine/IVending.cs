using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public interface IVending
    {
        void Purchase(int productIndex);
        List<string> ShowAll();
        void InsertMoney(double amount);
        double EndTransaction();
    }
}
