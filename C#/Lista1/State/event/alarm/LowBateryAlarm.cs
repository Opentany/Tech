using State.appliance;

namespace State.@event.alarm
{
    public class LowBateryAlarm extends Alarm {

	/**
	 * @param sourceAppliance
	 */
	public LowBateryAlarm(Appliance sourceAppliance) {
		super(sourceAppliance);

	}

}
}