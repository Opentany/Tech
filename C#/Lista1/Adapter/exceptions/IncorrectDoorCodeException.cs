using System;

namespace Adapter.exceptions
{
    public class IncorrectDoorCodeException : Exception
    {
        /**
	 * @param e
	 */

        public IncorrectDoorCodeException(string message) : base(message)
        {
        }

        /**
	 * 
	 */

        public IncorrectDoorCodeException()
        {
        }

        /**
	 * 
	 */
        private static readonly long serialVersionUID = 1L;
    }
}