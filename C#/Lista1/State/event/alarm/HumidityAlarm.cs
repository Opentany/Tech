using State.appliance;

namespace State.@event.alarm
{
    public class HumidityAlarm : Alarm {

	/**
	 * @param sourceAppliance
	 */
	public HumidityAlarm(Appliance sourceAppliance):base(sourceAppliance) {
		//super(sourceAppliance);

	}

}
}