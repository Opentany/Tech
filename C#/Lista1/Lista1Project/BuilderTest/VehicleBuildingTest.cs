using System;
using Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty.BuilderTest
{
    [TestClass]
    public class VehicleBuildingTest
    {
        private VehicleBuilder builder;

        // Create shop with vehicle builders
        private Shop shop = new Shop();
        [TestMethod]
        public void ScooterBuilding()
        {
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
            Assert.IsNotNull(builder);
        }

        [TestMethod]
        public void CarBuilding()
        {
            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
            Assert.IsNotNull(builder);
        }

        [TestMethod]
        public void MotorCycleBuilder()
        {
            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
            Assert.IsNotNull(builder);
        }
    }
}
