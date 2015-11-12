namespace State.appliance.state
{
    public class StoppedState : ApplianceStateBehavior {

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#getState()
	 */
	
	public ApplianceState getState() {
		return ApplianceState.STOPPED;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#start()
	 */
	
	public ApplianceStateBehavior start() {
		//Can start
	    return null;//ApplianceState.STARTED.getStateBehavior();
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#stop()
	 */
	
	public ApplianceStateBehavior stop() {
		// Already stopped
		return this;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOn()
	 */
	
	public ApplianceStateBehavior turnOn() {
		//It's started, so turned on
		return this;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOff()
	 */
	
	public ApplianceStateBehavior turnOff() {
		// After stopped, can go off
	    return null; //ApplianceState.OFF.getStateBehavior();
	}

}
}