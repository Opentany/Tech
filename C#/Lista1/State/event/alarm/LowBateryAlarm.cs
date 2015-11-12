using State.appliance;

namespace State.@event.alarm
{
    public class LowBateryAlarm : Alarm {

	/**
	 * @param sourceAppliance
	 */
	public LowBateryAlarm(Appliance sourceAppliance):base(sourceAppliance) {
		//super(sourceAppliance);

	}

}
}