using Facade.service;
using Moq;

namespace Facade
{
    public class DefaultBookstoreFacade : BookstoreFacade
    {
        private Mock<CustomerDBService> customer;
        private Mock<WharehouseService> wharehouse;
        private Mock<CustomerNotificationService> customerNotification;
        private Mock<OrderingService> ordering;
        private Mock<BookDBService> bookDb;
        

        public void placeOrder(string customerId, string isbn)
        {
            //customer.findCustomerById(customerId);
            //bookDb.findBookByISBN(isbn);
            //ordering.createOrder(customer.findCustomerById(customerId), bookDb.findBookByISBN(isbn));
            //wharehouse.dispatch(ordering.createOrder(customer.findCustomerById(customerId), bookDb.findBookByISBN(isbn)));
            //customerNotification.notifyClient(wharehouse.dispatch(ordering.createOrder(customer.findCustomerById(customerId), bookDb.findBookByISBN(isbn))));
        }

        public void setCustomerService(Mock<CustomerDBService> customerService)
        {
            customer = customerService;
        }

        public void setWharehouseService(Mock<WharehouseService> wharehouseService)
        {
            wharehouse = wharehouseService;
        }

        public void setCustomerNotificationService(Mock<CustomerNotificationService> customerNotificationService)
        {
            customerNotification = customerNotificationService;
        }

        public void setBookService(Mock<BookDBService> booksService)
        {
            bookDb = booksService;
        }

        public void setOrderinService(Mock<OrderingService> orderingService)
        {
            ordering = orderingService;
        }
    }
}