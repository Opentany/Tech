using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton2;

namespace UnitTesty
{
    [TestClass]
    public class UnitTest4
    {
        LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

        [TestMethod]
        public void TestIfSameInstance()
        {
            Assert.AreSame(b1, b2);
            Assert.AreSame(b2, b3);
            Assert.AreSame(b3, b4);
        }

        [TestMethod]
        public void LoadBalanceFor15ServerRequest()
        {
            for (int i=0; i < 15; i++)
            {
                b1.Server2();
                string server = b1.GetSer();

                Console.WriteLine("b1 Dispatch Request to: " + server +" "+ b1);
                server = b2.GetSer();

                Console.WriteLine("b2 Dispatch Request to: " + server + " " + b2);
                server = b3.GetSer();

                Console.WriteLine("b3 Dispatch Request to: " + server + " " + b3);
                server = b4.GetSer();

                Console.WriteLine("b4 Dispatch Request to: " + server + " " + b4);
                Assert.AreEqual(b1.GetSer(),b2.GetSer());
                Assert.AreEqual(b2.GetSer(), b3.GetSer());
                Assert.AreEqual(b3.GetSer(), b4.GetSer());

            }

        }

    }
}
