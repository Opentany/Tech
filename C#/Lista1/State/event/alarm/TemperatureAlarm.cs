using State.appliance;

namespace State.@event.alarm
{
    public class TemperatureAlarm extends Alarm {

	/**
	 * @param sourceAppliance
	 */
	public TemperatureAlarm(Appliance sourceAppliance) {
		super(sourceAppliance);
	}

}
}