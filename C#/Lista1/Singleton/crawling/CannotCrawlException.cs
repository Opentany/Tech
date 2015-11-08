using System;

namespace Singleton.crawling
{
    public class CannotCrawlException : Exception
    {
        /**
	 * 
	 */
        private static readonly long serialVersionUID = 5969531467220709871L;

        /**
	 * @param e
	 */

        public CannotCrawlException(string message) : base(message)
        {
        }
    }
}