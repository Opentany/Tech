using Facade.model;

namespace Facade.service
{
    public interface OrderingService
    {

        /**
         * @param customer
         * @param book
         * @return
         */
        Order createOrder(Customer customer, Book book);

    }
}