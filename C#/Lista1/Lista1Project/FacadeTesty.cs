using System;
using Facade2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty
{
    [TestClass]
    public class FacadeTesty
    {
        private Mortgage mortgage = new Mortgage();
 
      // Evaluate mortgage eligibility for customer
        private Customer customer = new Customer("Ann McKinsey");

        [TestMethod]
        public void BankTest()
        {
            bool eligible = mortgage.IsEligible(customer, 125000);
 
            Console.WriteLine("\n" + customer.Name +
            " has been " + (eligible ? "Approved" : "Rejected"));
            
        }
      
    }
}
