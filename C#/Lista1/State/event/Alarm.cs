using System;
using State.appliance;

namespace State.@event
{
    public abstract class Alarm : ApplianceEvent {

	private String additionalInfo;

	/**
	 * @param sourceAppliance
	 */
	public Alarm(Appliance sourceAppliance):base(sourceAppliance) {
		//super(sourceAppliance);
	}

	/**
	 * @param property
	 */
	public void setAditionalInfo(String property) {
		this.additionalInfo= property;
		
	}

}
}