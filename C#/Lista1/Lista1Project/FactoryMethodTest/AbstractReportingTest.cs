using System;
using FactoryMethod;

namespace UnitTesty.FactoryMethodTest
{
    public abstract class AbstractReportingTest
    {


        private Random random = new Random();


        /**
         * Create a dummy ReportData Object
         * @return
         */
        protected ReportData createDummyReportData()
        {
            ReportData dummyReportDate = new ReportData();
            dummyReportDate.setName("Dummy " + generateRandomString());
            return dummyReportDate;
        }

        /**
         * Generate an random String
         * @return
         */
        private String generateRandomString()
        {
            //return new BigInteger(132, random).toString(32);
            var ran = random.Next(Int32.MaxValue);
            return Convert.ToString(ran, 16);
        }



    }
}
