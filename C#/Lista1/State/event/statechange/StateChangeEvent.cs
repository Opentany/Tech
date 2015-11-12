using State.appliance;

namespace State.@event.statechange
{
    public class StateChangeEvent extends ApplianceEvent {

	/**
	 * @param sourceAppliance
	 */
	public StateChangeEvent(Appliance sourceAppliance) {
		super(sourceAppliance);

	}

	
	
}
}