using State.appliance;

namespace State.@event
{
    public class AttributeChangeEvent extends StateChangeEvent {

	/**
	 * @param sourceAppliance
	 */
	public AttributeChangeEvent(Appliance sourceAppliance) {
		super(sourceAppliance);

	}

}
}