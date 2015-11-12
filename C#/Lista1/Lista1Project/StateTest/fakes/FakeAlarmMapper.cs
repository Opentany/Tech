using System;
using State.appliance;

namespace UnitTesty.StateTest.fakes
{
    public class FakeAlarmMapper : EventMapper {

	
	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.mapper.EventMapper
	 * #doMap(eu.jpereira.trainings.designpatterns.behavioral.observer.event.
	 * EventData,
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.event.
	 * ApplianceEvent,
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.mapper
	 * .MapperChain)
	 */
	@Override
	public void doMap(EventData data, MapperChain chain) {

		if ( data.getEvent()==null || data.getEvent().getSourceAppliance()==null) {
			throw new IllegalStateException("Must run any mapper before this in order to fill the event with the righjt appliance");
		}
		
		//check if the event is an alarm
		if (data.getProperty("type").equals("alarm")) {
			Alarm alarm = createAlarm(data.getProperty("alarmName"),data.getEvent().getSourceAppliance());
			alarm.setAditionalInfo(data.getProperty("aditionalInfo"));
			data.setEvent(alarm);
		}
		
		chain.doMap(data);

	}

	/**
	 * @param property
	 * @return
	 */
	private Alarm createAlarm(String property, Appliance appliance) {
		Alarm theAlarm = null;
		//fake object, instantiate this for testing
		if ( property.equals("highTemp")) {
			theAlarm = new TemperatureAlarm(appliance);
		}
		return theAlarm ;
	}

}
}