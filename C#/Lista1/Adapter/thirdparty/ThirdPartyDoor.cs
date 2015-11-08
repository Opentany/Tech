using System;
using Adapter.thirdparty.exceptions;

namespace Adapter.thirdparty
{
    public class ThirdPartyDoor
    {
        public enum LockStatus
        {
            LOCKED,
            UNLOCKED
        }

        public enum DoorState
        {
            OPEN,
            CLOSED
        }

        public static readonly String DEFAULT_CODE = "AAAAHHHH";
        private String code = DEFAULT_CODE;
        private LockStatus lockStatus = LockStatus.LOCKED;
        private DoorState doorState = DoorState.CLOSED;


        /**
	 * Before you can use this instance, you unlock the door
	 * @param usedCode
	 */

        public void unlock(String code)
        {
// throws CannotUnlockDoorException {
            if (code.Equals(this.code))
            {
                lockStatus = LockStatus.UNLOCKED;
            }
            else
            {
                throw new CannotUnlockDoorException();
            }
        }


        /**
	 * @return
	 */

        public LockStatus getLockStatus()
        {
            return this.lockStatus;
        }


        /**
	 * @return
	 */

        public DoorState getState()
        {
            return this.doorState;
        }


        /**
	 * @param state
	 */

        public void setState(DoorState state)
        {
//throws CannotChangeStateOfLockedDoor {
            if (this.lockStatus.Equals(LockStatus.LOCKED))
            {
                throw new CannotChangeStateOfLockedDoor();
            }
            this.doorState = state;
        }


        /**
	 * 
	 */

        public void Locker()
        {
            this.lockStatus = LockStatus.LOCKED;
        }


        /**
	 * @param newCode
	 * @throws CannotChangeCodeForUnlockedDoor 
	 */

        public void setNewLockCode(String newCode)
        {
// throws CannotChangeCodeForUnlockedDoor {
            if (this.lockStatus.Equals(LockStatus.LOCKED))
            {
                throw new CannotChangeCodeForUnlockedDoor();
            }
            this.code = newCode;
        }
    }
}