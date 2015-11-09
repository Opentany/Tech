using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public interface BookstoreFacade
    {

        /**
         * @param customerId
         * @param isbn
         */
        void placeOrder(String customerId, String isbn);

    }
}
