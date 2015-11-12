using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State.appliance;
using State.appliance.state;

namespace UnitTesty.StateTest.appliance.state
{
    [TestClass]
    public class ApplianceStateBehaviorTest {
	
	
	
	[TestMethod]
	public void testOffToOn(){// throws ApplianceCommunicationException {
		//Toaster is the test we will use to test
		Appliance appliance = createAppliance(ApplianceState.OFF);
		appliance.turnOn();
		Assert.AreEqual(ApplianceState.ON, appliance.getState());
		
	}
	[TestMethod]
	public void testOnToStarted(){//throws ApplianceCommunicationException {
		Appliance appliance = createAppliance(ApplianceState.ON);
		appliance.start();
        Assert.AreEqual(ApplianceState.STARTED, appliance.getState());
	}
	
	[TestMethod]
	public void testStartedToStopped() {// ApplianceCommunicationException {
		Appliance appliance = createAppliance(ApplianceState.STARTED);
		appliance.stop();
		Assert.AreEqual(ApplianceState.STOPPED, appliance.getState());
	}

	[TestMethod]
	public void testStoppedToOff() {// ApplianceCommunicationException {
		Appliance appliance = createAppliance(ApplianceState.STOPPED);
		appliance.turnOff();
		Assert.AreEqual(ApplianceState.OFF, appliance.getState());
	}

	
	/**
	 * @return
	 */
	private Appliance createAppliance(ApplianceState state) {
		return new Toaster(state);
	}

}
}
