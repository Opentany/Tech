using System;
using Lista1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lista1Project
{
    [TestClass]
    public class NumberTests
    {
        readonly Number _num=new Number(144);
        [TestMethod]
        //MethodName_StateUnderTest_ExpectedBehavior
        public void ToBase_ToBase2_True()
        {
            //arrange
            var actual = _num.ToBase(2);
            const string expected = "10010000";
            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void ToBase_ToBase16_False()
        {
            //arrange
            var actual = _num.ToBase(16);
            const string notexpected = "91"; //true value of 114 in base16 is 90
            //assert
            Assert.AreNotEqual(notexpected,actual);
        }

        [Ignore]
        public void ToBase_ToBase19_ExceptionPlusFail()
        {
            try
            {
                var actual = _num.ToBase(19);
            }
            catch (ArgumentException ex)
            {

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void SomethingMustBeFalse_IsFalse_ReallyIs()
        {
            
            //arrange
            var condition = _num.SomethingMustBeFalse();
            //assert
            Assert.IsFalse(condition);
        }
        [TestMethod]
        public void _num_IsTypeOfNumber_ItIsNot()
        {
            //assert
            Assert.IsNotInstanceOfType(_num.ToBase(2), typeof (Number));
        }
        
    }
}
