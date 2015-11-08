using System;
using Adapter.model;
using Adapter.thirdparty;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty.AdapterTests.thirdparty
{
    [TestClass]
    public class ThirdPartyDoorObjectAdapterTest : DoorTest
    {
        protected override IDoor createDoorUnderTest()
        {
            //return new SimpleDoor();
            return new ThirdPartyDoorObjectAdapter();
        }

        protected override String getDefaultDoorCode()
        {
            //return SimpleDoor.DEFAULT_DOOR_CODE;
            return ThirdPartyDoor.DEFAULT_CODE;
        }
    }
}
