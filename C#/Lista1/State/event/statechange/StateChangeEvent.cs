using State.appliance;

namespace State.@event.statechange
{
    public class StateChangeEvent : ApplianceEvent {

	/**
	 * @param sourceAppliance
	 */
        public StateChangeEvent(Appliance sourceAppliance)
            : base(sourceAppliance)
        {
            //super(sourceAppliance);

	}

	
	
}
}