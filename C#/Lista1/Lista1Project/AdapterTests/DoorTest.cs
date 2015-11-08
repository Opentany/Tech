using System;
using Adapter.exceptions;
using Adapter.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty.AdapterTests
{
    [TestClass]
    public class DoorTest
    {
        protected DoorTest()
        {
        }

        [TestMethod]
        public void shouldOpenDoor()
        {
// throws IncorrectDoorCodeException {
            IDoor door = createDoorUnderTest();
            door.Open(getDefaultDoorCode());
            Assert.IsTrue(door.IsOpen());
        }


        //@Test(expected=IncorrectDoorCodeException.class)
        [TestMethod]
        [ExpectedException(typeof (IncorrectDoorCodeException))]
        public void shouldThrowExceptionForWrongCode()
        {
// throws IncorrectDoorCodeException {
            IDoor door = createDoorUnderTest();
            door.Open("SomeHCode");
        }

        [TestMethod]
        public void shouldCloseDoor()
        {
            //throws IncorrectDoorCodeException {
            IDoor door = createDoorUnderTest();
            door.Open(getDefaultDoorCode());
            Assert.IsTrue(door.IsOpen());
            //close it
            door.Close();
            Assert.IsFalse(door.IsOpen());
        }

        [TestMethod]
        public void testChangeCode()
        {
//throws IncorrectDoorCodeException, CodeMismatchException {
            IDoor door = createDoorUnderTest();
            door.ChangeCode(getDefaultDoorCode(), "123", "123");
            Assert.IsTrue(door.TestCode("123"));
        }

        //@Test(expected=IncorrectDoorCodeException.class)
        [TestMethod]
        [ExpectedException(typeof (IncorrectDoorCodeException))]
        public void testThrowExceptionForIncorrectCodeChangingCode()
        {
            //throws IncorrectDoorCodeException, CodeMismatchException {
            IDoor door = createDoorUnderTest();
            door.ChangeCode("Dummy", "123", "123");
        }

        //@Test(expected=CodeMismatchException.class)
        [TestMethod]
        [ExpectedException(typeof (CodeMismatchException))]
        public void testThrowExceptionForMismatchNewCode()
        {
            //throws IncorrectDoorCodeException, CodeMismatchException {
            IDoor door = createDoorUnderTest();
            door.ChangeCode(getDefaultDoorCode(), "123", "1a23");
        }


        /**
	 * @return
	 */

        protected virtual IDoor createDoorUnderTest()
        {
            // TODO Auto-generated method stub
            return new SimpleDoor();
        }


        /**
	 * @return
	 */

        protected virtual String getDefaultDoorCode()
        {
            return SimpleDoor.DEFAULT_DOOR_CODE;
        }
    }
}
