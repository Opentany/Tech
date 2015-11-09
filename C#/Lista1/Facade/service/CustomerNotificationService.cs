using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Facade.model;

namespace Facade.service
{
    public interface CustomerNotificationService
    {

        /**
         * @param order
         */
        void notifyClient(Order order);

        /**
         * @param dispatchReceipt
         */
        void notifyClient(DispatchReceipt dispatchReceipt);

       
    }
}