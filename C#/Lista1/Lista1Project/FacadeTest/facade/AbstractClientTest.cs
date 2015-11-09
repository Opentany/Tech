using Facade.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTesty.FacadeTest.client
{
    [TestClass]
    public class AbstractClientTest
    {
        // Get the required services
        protected Mock<CustomerDBService> customerService;
        protected Mock<BookDBService> bookService;
        protected Mock<OrderingService> orderingService;
        protected Mock<CustomerNotificationService> customerNotificationService;
        protected Mock<WharehouseService> wharehouseService;

        [ClassInitialize]
        public void setupFakeServices()
        {
            // Get the required services
            // Use as a mock
            customerService = getMockedCustomerDBService();
            bookService = getMockedBookDBService();
            orderingService = getMockedOrderingService();
            customerNotificationService = getMockedCustomerNotificationService();
            wharehouseService = getMockedWhareHouseService();
        }

        /**
	 * Factory Method
	 * 
	 * @return
	 */

        protected Mock<CustomerDBService> getMockedCustomerDBService()
        {
            Mock<CustomerDBService> mock = new Mock<CustomerDBService>();
            return mock;
        }

        /**
	 * Factory Method
	 * 
	 * @return
	 */

        protected Mock<BookDBService> getMockedBookDBService()
        {
            Mock<BookDBService> mock = new Mock<BookDBService>();
            return mock;
        }

        /**
	 * Factory Method
	 * 
	 * @return
	 */

        protected Mock<OrderingService> getMockedOrderingService()
        {
            Mock<OrderingService> mock = new Mock<OrderingService>();
            return mock;
        }

        /**
	 * Factory method
	 * 
	 * @return
	 */

        protected Mock<CustomerNotificationService> getMockedCustomerNotificationService()
        {
            Mock<CustomerNotificationService> mock = new Mock<CustomerNotificationService>();
            return mock;
        }

        /**
	 * Factory method
	 * 
	 * @return
	 */

        protected Mock<WharehouseService> getMockedWhareHouseService()
        {
            Mock<WharehouseService> mock = new Mock<WharehouseService>();
            return mock;
        }
    }
}
