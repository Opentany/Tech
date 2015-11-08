using System;
using Adapter.exceptions;
using Adapter.model;
using Adapter.thirdparty.exceptions;

namespace Adapter.thirdparty
{
    public class ThirdPartyDoorAdaper : ThirdPartyDoor, IDoor
    {
        public void Open(string code)
        {
            try
            {
                unlock(code);
                setState(DoorState.OPEN);
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
            setState(DoorState.CLOSED);
            Locker();
            
        }

        public bool IsOpen()
        {
            if (getState().Equals(DoorState.OPEN))
            {
                return true;
            }
            return false;
        }

        public void ChangeCode(string oldCode, string newCode, string newCodeConfirmation)
        {
            try
            {
                unlock(oldCode);
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
            setNewLockCode(newCode);
        }

        public bool TestCode(string code)
        {
            try
            {
                unlock(code);
            }
            catch (CannotUnlockDoorException e)
            {

                return false;
            }
            return true;
        }
    }
}