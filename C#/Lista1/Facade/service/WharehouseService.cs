using System;
using System.Linq.Expressions;
using Facade.model;

namespace Facade.service
{
    public interface WharehouseService
    {

        /**
         * @param order
         * @return
         */
        DispatchReceipt dispatch(Order order);

    }
}