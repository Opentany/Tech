using Facade.service;

namespace Facade
{
    public class DefaultBookstoreFacade : BookstoreFacade
    {

        public void placeOrder(string customerId, string isbn)
        {
            throw new System.NotImplementedException();
        }

        public void setCustomerService(CustomerDBService customerService)
        {
            
        }

        public void setWharehouseService(WharehouseService wharehouseService)
        {
            
        }

        public void setCustomerNotificationService(CustomerNotificationService customerNotificationService)
        {
            
        }

        public void setBookService(BookDBService booksService)
        {
            
        }

        public void setOrderinService(OrderingService orderingService)
        {
            
        }
    }
}