using System;

namespace Adapter.model
{
    public interface IDoor
    {
        /**
	 * Open the door if the code is correct
	 * 
	 * @param code
	 *            the code to open the door
	 * @throws IncorrectDoorCodeException
	 *             if the code is not correct
	 */
        void Open(String code); //throws IncorrectDoorCodeException;

        /**
	 * Attempt to close the door
	 */
        void Close();

        /**
	 * Test if the door is open
	 * 
	 * @return
	 */
        bool IsOpen();

        /**
	 * Attempt to change the door code
	 * 
	 * @param oldCode
	 *            The old code
	 * @param newCode
	 *            the new code
	 * @param newCodeConfirmation
	 *            the new code confirmation
	 * @throws IncorrectDoorCodeException
	 */
        void ChangeCode(String oldCode, String newCode, String newCodeConfirmation);
        //throws IncorrectDoorCodeException, CodeMismatchException;

        /**
	 * Test if a given code can open the door
	 * 
	 * @param code
	 *            the code to test
	 * @return true if the code can open the door, false otherwise
	 */
        bool TestCode(String code);
    }
}