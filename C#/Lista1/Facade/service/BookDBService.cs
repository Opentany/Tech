using System;
using Facade.model;

namespace Facade.service
{
    public interface BookDBService
    {

        /**
         * @param isbn
         * @return
         */

        Book findBookByISBN(String isbn);


    }
}