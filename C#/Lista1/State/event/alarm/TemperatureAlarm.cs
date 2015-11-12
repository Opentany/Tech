using State.appliance;

namespace State.@event.alarm
{
    public class TemperatureAlarm : Alarm {

	/**
	 * @param sourceAppliance
	 */
	public TemperatureAlarm(Appliance sourceAppliance):base(sourceAppliance) {
		//super(sourceAppliance);
	}

}
}