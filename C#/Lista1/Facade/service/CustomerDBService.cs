using System;
using Facade.model;

namespace Facade.service
{
    public interface CustomerDBService
    {

        /**
         * @param customerId
         * @return
         */
        Customer findCustomerById(String customerId);

    }
}