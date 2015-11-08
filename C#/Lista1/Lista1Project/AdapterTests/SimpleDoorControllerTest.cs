using System;
using Adapter;
using Adapter.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTesty.AdapterTests
{
    [TestClass]
    public class SimpleDoorControllerTest
    {
        //@Test(expected = DoorNotManagedException.class)
        [TestMethod]
        [ExpectedException(typeof (DoorNotManagedException))]
        public void testShouldThrowExceptionForInexistentDoor()
        {
            //throws DoorNotManagedException, IncorrectDoorCodeException {
            // Create a simple dummy door, conforming the Interface Door
            Mock<IDoor> aDoor = createMockedDoor();

            // Add this door to the controller
            IDoorController controller = createDoorControllerUnderTest();
            // do not add the door. Is expected an exception;
            // can use any code, it's outside of test scope here
            controller.OpenDoor(aDoor.Object, getDefaultCodeForDoor());
        }

        [TestMethod]
        public void testShouldNotAddSameElement()
        {
            // Create a simple dummy door, conforming the Interface Door
            Mock<IDoor> mockedDoor = createMockedDoor();
            IDoorController controller = createDoorControllerUnderTest();
            controller.AddDoor(mockedDoor.Object);

            Assert.AreEqual(1, controller.CountManagedDoors());
            controller.AddDoor(mockedDoor.Object);
            Assert.AreEqual(1, controller.CountManagedDoors());
        }

        [TestMethod]
        public void testShouldOpenDoor()
        {
// throws DoorNotManagedException, IncorrectDoorCodeException {
            // Create a simple dummy door, conforming the Interface Door
            Mock<IDoor> door = createMockedDoor();
            // Add this door to the controller
            IDoorController controller = createDoorControllerUnderTest();
            controller.AddDoor(door.Object);
            // can use any code, it's outside of test scope here
            controller.OpenDoor(door.Object, getDefaultCodeForDoor());
            // ensure that the door open() was called in the targetDoor
            //verify(door).open(getDefaultCodeForDoor());
            door.Verify(mock => mock.Open(getDefaultCodeForDoor()));
        }

        [TestMethod]
        public void testShouldCloseDoor()
        {
// throws DoorNotManagedException, IncorrectDoorCodeException {
            Mock<IDoor> mockedDoor = createMockedDoor();
            IDoorController controller = createDoorControllerUnderTest();
            // Add the door to the controller
            controller.AddDoor(mockedDoor.Object);
            // Open the door
            controller.OpenDoor(mockedDoor.Object, getDefaultCodeForDoor());
            //verify(mockedDoor).open(getDefaultCodeForDoor());
            mockedDoor.Verify(mock => mock.Open(getDefaultCodeForDoor()));
            controller.CloseDoor(mockedDoor.Object);
            //verify(mockedDoor).close();
            mockedDoor.Verify(mock => mock.Close());
        }

        //@Test(expected = DoorNotManagedException.class)
        [TestMethod]
        [ExpectedException(typeof (DoorNotManagedException))]
        public void testShouldThrowExceptionClosingNotManagedDoor()
        {
// throws DoorNotManagedException, IncorrectDoorCodeException {
            Mock<IDoor> mockedDoor = createMockedDoor();
            IDoorController controller = createDoorControllerUnderTest();
            // dont add the door to the controller
            controller.CloseDoor(mockedDoor.Object);
        }

        /**
	 * Factory method for the door controller
	 * 
	 * @return
	 */

        protected IDoorController createDoorControllerUnderTest()
        {
            return new SimpleDoorController();
        }

        /**
	 * @return
	 */

        protected String getDefaultCodeForDoor()
        {
            return SimpleDoor.DEFAULT_DOOR_CODE;
        }

        /**
	 * Factory method for test door
	 * 
	 * @return
	 */

        protected Mock<IDoor> createMockedDoor()
        {
            return new Mock<IDoor>();
        }
    }
}
