using System;
using Adapter.thirdparty;
using Adapter.thirdparty.exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty.AdapterTests.thirdparty
{
    [TestClass]
    public class ThirdPartyDoorTest
    {
        [TestMethod]
        // Shoudl not throw any exception
        public void testUnlockDoor()
        {
//throws CannotUnlockDoorException {
            ThirdPartyDoor door = createThirtPartyDoor();
            door.unlock(getThirdPartyDoorCode());
            Assert.IsTrue(door.getLockStatus().Equals(ThirdPartyDoor.LockStatus.UNLOCKED));
        }

        //@Test(expected = CannotUnlockDoorException.class)
        [TestMethod]
        [ExpectedException(typeof (CannotUnlockDoorException))]
        public void testUnlockDoorIncorrectCode()
        {
            //throws CannotUnlockDoorException {
            ThirdPartyDoor door = createThirtPartyDoor();
            door.unlock("Som code");
        }

        [TestMethod]
        public void testLockDoor()
        {
            //throws CannotUnlockDoorException {
            ThirdPartyDoor door = createThirtPartyDoor();
            door.unlock(getThirdPartyDoorCode());
            Assert.IsTrue(door.getLockStatus().Equals(ThirdPartyDoor.LockStatus.UNLOCKED));
            //Now lock it
            door.Locker();
            Assert.IsTrue(door.getLockStatus().Equals(ThirdPartyDoor.LockStatus.LOCKED));
        }

        [TestMethod]
        public void defaultDoorStateShouldBeClosed()
        {
            ThirdPartyDoor door = createThirtPartyDoor();
            Assert.AreEqual(ThirdPartyDoor.DoorState.CLOSED, door.getState());
        }

        [TestMethod]
        public void openDoor()
        {
            //throws CannotUnlockDoorException, CannotChangeStateOfLockedDoor {
            ThirdPartyDoor door = createThirtPartyDoor();
            //Unlock it
            door.unlock(getThirdPartyDoorCode());
            //Now open it
            door.setState(ThirdPartyDoor.DoorState.OPEN);
            Assert.AreEqual(ThirdPartyDoor.DoorState.OPEN, door.getState());
        }

        //@Test(expected=CannotChangeStateOfLockedDoor.class)
        [TestMethod]
        [ExpectedException(typeof (CannotChangeStateOfLockedDoor))]
        public void cannotOpenLockedDoor()
        {
            //throws CannotChangeStateOfLockedDoor {
            ThirdPartyDoor door = createThirtPartyDoor();
            //Do not unlock it
            door.setState(ThirdPartyDoor.DoorState.OPEN);
        }

        [TestMethod]
        public void changeCode()
        {
            //throws CannotUnlockDoorException, CannotChangeCodeForUnlockedDoor {
            ThirdPartyDoor door = createThirtPartyDoor();
            door.unlock(getThirdPartyDoorCode());
            door.setNewLockCode("Some Code");

            //Lock it
            door.Locker();
            //Try to unlock it
            door.unlock("Some Code");
        }

        //@Test(expected=CannotChangeCodeForUnlockedDoor.class)
        [TestMethod]
        [ExpectedException(typeof (CannotChangeCodeForUnlockedDoor))]
        public void cannotChangeCodeForLockedDoor()
        {
            //throws CannotChangeCodeForUnlockedDoor {
            ThirdPartyDoor door = createThirtPartyDoor();
            //Do not unlock it
            door.setNewLockCode("123");
        }

        /**
	 * @return
	 */

        private String getThirdPartyDoorCode()
        {
            // TODO Auto-generated method stub
            return ThirdPartyDoor.DEFAULT_CODE;
        }

        /**
	 * @return
	 */

        private ThirdPartyDoor createThirtPartyDoor()
        {
            return new ThirdPartyDoor();
        }
    }
}
