using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State2;

namespace UnitTesty
{
    [TestClass]
    public class State2Test
    {
        Account account = new Account("Jim Johnson");
        [TestMethod]
        public void ApplyFinancialTransactions()
        {
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
    }
}
