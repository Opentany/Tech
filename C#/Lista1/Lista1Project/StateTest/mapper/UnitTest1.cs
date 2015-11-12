using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty.StateTest.mapper
{
    [TestClass]
    public class EventMapperTest {

	@Test
	public void testAlarm() {

		// Create a new MapperChain
		MapperChain chain = new MapperChain();

		chain.addToChain(new ApplianceEventMapper(createApplianceDAO()));
		chain.addToChain(new FakeStateChangeMapper());
		chain.addToChain(new FakeAlarmMapper());

		// create dummy EventData
		EventData eventData = createAlarmEventData();

		chain.doMap(eventData);
		assertNotNull(eventData);
		assertNotNull(eventData.getEvent().getSourceAppliance());
		assertEquals("12.12.12.12", eventData.getEvent().getSourceAppliance().getIpAddress());
		assertTrue(eventData.getEvent() instanceof Alarm);
	}

	
	@Test
	public void testStateChange() {

		// Create a new MapperChain
		MapperChain chain = new MapperChain();

		chain.addToChain(new ApplianceEventMapper(createApplianceDAO()));
		chain.addToChain(new FakeStateChangeMapper());
		chain.addToChain(new FakeAlarmMapper());

		// create dummy EventData
		EventData eventData = createStateChangeEventData();

		chain.doMap(eventData);
		assertNotNull(eventData);
		assertNotNull(eventData.getEvent().getSourceAppliance());
		assertEquals("12.12.12.12", eventData.getEvent().getSourceAppliance().getIpAddress());

		assertTrue(eventData.getEvent() instanceof StateChangeEvent);
	}
	

	/**
	 * @return
	 */
	private ApplianceDAO createApplianceDAO() {
		return new FakeApplianceDAO();
	}

	/**
	 * @return
	 */
	private EventData createAlarmEventData() {
		EventData data = new EventData();
		data.setProperty("applianceMacAddress", "AA.BB.CC");
		data.setProperty("type", "alarm");
		data.setProperty("alarmName", "highTemp");
		data.setProperty("aditionalInfo", "400");
		return data;
	}
	
	/**
	 * @return
	 */
	private EventData createStateChangeEventData() {
		EventData data = new EventData();
		data.setProperty("applianceMacAddress", "AA.BB.CC");
		data.setProperty("type", "stateChange");
		data.setProperty("attributeName", "temperature");
		data.setProperty("attributeLastValue", "350");
		data.setProperty("attributeNewValue", "400");
		return data;
	}

}
}
