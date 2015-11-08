using System;
using Adapter.exceptions;

namespace Adapter.model
{
    public class SimpleDoor : IDoor
    {
        public static String DEFAULT_DOOR_CODE = "AAFF1299BFA";

        private String code = DEFAULT_DOOR_CODE;

        private bool open = false;

        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.structural.adapter.model.DoorDriver
	 * #open(java.lang.String)
	 */

        public void Open(String code)
        {
// throws IncorrectDoorCodeException {
            // try the code
            if (this.code.Equals(code))
            {
                open = true;
            }
            else
            {
                throw new IncorrectDoorCodeException();
            }
        }

        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.structural.adapter.model.DoorDriver
	 * #close()
	 */

        public void Close()
        {
            this.open = false;
        }

        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.structural.adapter.model.DoorDriver
	 * #isOpen()
	 */

        public bool IsOpen()
        {
            return this.open;
        }

        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.structural.adapter.model.DoorDriver
	 * #changeCode(java.lang.String, java.lang.String, java.lang.String)
	 */

        public void ChangeCode(String oldCode, String newCode, String newCodeConfirmation)
        {
// throws IncorrectDoorCodeException, CodeMismatchException {

            if (newCode.Equals(newCodeConfirmation))
            {
                if (oldCode.Equals(this.code))
                {
                    this.code = newCode;
                }
                else
                {
                    throw new IncorrectDoorCodeException();
                }
            }
            else
            {
                throw new CodeMismatchException();
            }
        }

        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.structural.adapter.model.DoorDriver
	 * #testCode(java.lang.String)
	 */

        public bool TestCode(String code)
        {
            return code.Equals(this.code);
        }
    }
}