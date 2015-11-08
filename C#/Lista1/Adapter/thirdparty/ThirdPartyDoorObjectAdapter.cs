using Adapter.exceptions;
using Adapter.model;
using Adapter.thirdparty.exceptions;

namespace Adapter.thirdparty
{
    public class ThirdPartyDoorObjectAdapter : IDoor
    {
        private ThirdPartyDoor delegatDoor;

        public ThirdPartyDoorObjectAdapter()
        {
            delegatDoor = CreateNewThirdDoorParty();
        }
        public void Open(string code)
        {
            try
            {
                delegatDoor.unlock(code);
                delegatDoor.setState(ThirdPartyDoor.DoorState.OPEN);
            }
            catch (CannotUnlockDoorException e)
            {

                throw new IncorrectDoorCodeException(e.Message);
            }
            catch (CannotChangeCodeForUnlockedDoor e)
            {
                throw new IncorrectDoorCodeException(e.Message);
            }
        }

        public void Close()
        {
            delegatDoor.setState(ThirdPartyDoor.DoorState.CLOSED);
            delegatDoor.Locker();
        }

        public bool IsOpen()
        {
            if (delegatDoor.getState().Equals(ThirdPartyDoor.DoorState.OPEN))
            {
                return true;
            }
            return false;
        }

        public void ChangeCode(string oldCode, string newCode, string newCodeConfirmation)
        {
            try
            {
                delegatDoor.unlock(oldCode);
                if (newCode != newCodeConfirmation)
                {
                    throw new CodeMismatchException();
                }
            }
            catch (CannotUnlockDoorException e)
            {

                throw new IncorrectDoorCodeException(e.Message);
            }
            catch (CodeMismatchException)
            {
                throw new CodeMismatchException();
            }
            delegatDoor.setNewLockCode(newCode);
        }

        public bool TestCode(string code)
        {
            try
            {
                delegatDoor.unlock(code);
            }
            catch (CannotUnlockDoorException e)
            {

                return false;
            }
            return true;
        }

        protected ThirdPartyDoor CreateNewThirdDoorParty()
        {
            return new ThirdPartyDoor();
        }
    }
}