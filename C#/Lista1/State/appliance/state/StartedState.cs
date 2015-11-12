namespace State.appliance.state
{
    public class StartedState : ApplianceStateBehavior {

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#getState()
	 */
	
	public ApplianceState getState() {
		//TODO: Return the correct ApplianceState
		return ApplianceState.STARTED;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#start()
	 */
	
	public ApplianceStateBehavior start() {
		// Already started
		
		return this;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#stop()
	 */
	
	public ApplianceStateBehavior stop() {
		// Can go to Stop state
	    return null; //ApplianceState.STOPPED.getStateBehavior();
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOn()
	 */
	
	public ApplianceStateBehavior turnOn() {
		//Can't turn off when started
		return this;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOff()
	 */
	
	public ApplianceStateBehavior turnOff() {
		// Can't turn off on STARTED
		return this;
	}

}
}