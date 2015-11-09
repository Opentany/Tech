using System;
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
        Expression<Action<CustomerNotificationService>> notifyClient(DispatchReceipt dispatchReceipt);

        Expression<Action<CustomerNotificationService>> notifyClient(Expression<Action<WharehouseService>> dummyDispatchReceipt);
    }
}