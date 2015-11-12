namespace State.appliance.state
{
    public class OnState : ApplianceStateBehavior {

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#getState()
	 */
	
	public ApplianceState getState() {
		return ApplianceState.ON;
		//TODO: return the correnponding state enum. This represents the ON State, so return ApplianceState.ON;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#start()
	 */
	
	public ApplianceStateBehavior start() {
		//TODO: return the STARTED Behavior ApplianceState.STARTED.getStateBehavior()
		return null;
		
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#stop()
	 */
	
	public ApplianceStateBehavior stop() {
		//Can't stop from ON state
		return this;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOn()
	 */
	
	public ApplianceStateBehavior turnOn() {
		//Already on
		return this;
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.state.appliance.state.ApplianceStateBehavior#turnOff()
	 */
	
	public ApplianceStateBehavior turnOff() {
		//Go Off
	    return null; //ApplianceState.OFF.getStateBehavior();
	}

}
}