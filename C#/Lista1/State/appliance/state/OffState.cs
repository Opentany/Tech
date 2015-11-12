namespace State.appliance.state
{
    public class OffState : ApplianceStateBehavior {

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#getState()
	 */
	
	public ApplianceState getState() {
		
		return ApplianceState.OFF;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#start()
	 */

	public ApplianceStateBehavior start() {
		
		//Do nothing, can't go to started when off. Must return the same state
		//TODO: Return a reference to this object
		return null;
		
		
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#stop()
	 */

	public ApplianceStateBehavior stop() {
		//Do nothing. Can't go from OFF to STOPPED
		//TODO: Return a reference to this object
		return null;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOn()
	 */

	public ApplianceStateBehavior turnOn() {
		//Can go from OFF state (this) to ON state
		//TODO: Return the behavior for ON .Example: return ApplianceState.ON.getStateBehavior();
		
		return null;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOff()
	 */

	public ApplianceStateBehavior turnOff() {
		//Do nothing. It's already off
		return this;
	}

}
}