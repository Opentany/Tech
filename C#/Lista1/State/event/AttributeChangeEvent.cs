using State.appliance;
using State.@event.statechange;

namespace State.@event
{
    public class AttributeChangeEvent : StateChangeEvent {

	/**
	 * @param sourceAppliance
	 */
	public AttributeChangeEvent(Appliance sourceAppliance):base(sourceAppliance) {
		//super(sourceAppliance);

	}

}
}