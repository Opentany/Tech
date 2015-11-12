using System;
using State.appliance;

namespace State.@event
{
    public abstract class Alarm extends ApplianceEvent {

	private String additionalInfo;

	/**
	 * @param sourceAppliance
	 */
	public Alarm(Appliance sourceAppliance) {
		super(sourceAppliance);
	}

	/**
	 * @param property
	 */
	public void setAditionalInfo(String property) {
		this.additionalInfo= property;
		
	}

}
}