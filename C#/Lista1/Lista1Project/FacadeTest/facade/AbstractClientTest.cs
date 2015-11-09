using Facade.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTesty.FacadeTest.client
{
    [TestClass]
    public class AbstractClientTest
    {
        // Get the required services
        protected CustomerDBService customerService;
        protected BookDBService bookService;
        protected OrderingService orderingService;
        protected CustomerNotificationService customerNotificationService;
        protected WharehouseService wharehouseService;

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

        protected CustomerDBService getMockedCustomerDBService()
        {
            Mock<CustomerDBService> mock = new Mock<CustomerDBService>();
            return mock.Object;
        }

        /**
	 * Factory Method
	 * 
	 * @return
	 */

        protected BookDBService getMockedBookDBService()
        {
            Mock<BookDBService> mock = new Mock<BookDBService>();
            return mock.Object;
        }

        /**
	 * Factory Method
	 * 
	 * @return
	 */

        protected OrderingService getMockedOrderingService()
        {
            Mock<OrderingService> mock = new Mock<OrderingService>();
            return mock.Object;
        }

        /**
	 * Factory method
	 * 
	 * @return
	 */

        protected CustomerNotificationService getMockedCustomerNotificationService()
        {
            Mock<CustomerNotificationService> mock = new Mock<CustomerNotificationService>();
            return mock.Object;
        }

        /**
	 * Factory method
	 * 
	 * @return
	 */

        protected WharehouseService getMockedWhareHouseService()
        {
            Mock<WharehouseService> mock = new Mock<WharehouseService>();
            return mock.Object;
        }
    }
}
