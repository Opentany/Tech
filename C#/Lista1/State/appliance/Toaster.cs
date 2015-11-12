using State.appliance.snapshot;
using State.appliance.state;

namespace State.appliance
{
    public class Toaster :AbstractAppliance {

	/**
	 * @param initialState
	 */
	public Toaster(ApplianceState initialState):base(initialState) {
		
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.snapshot
	 * .Snapshotable#takeSnapshot()
	 */

	public override Snapshot takeSnapshot() {
		return null;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.snapshot
	 * .Snapshotable#restoreFromSnapshot(eu.jpereira.trainings.designpatterns.
	 * behavioral.observer.appliance.snapshot.Snapshot)
	 */

	public override void restoreFromSnapshot(Snapshot snapshot) {

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.Appliance
	 * #turnOn()
	 */

	public override void turnOn(){// throws ApplianceCommunicationException {
		// TODO: Delegate to the the current ApplianceStateBehavior and set
		// this.applianceStateBehavior to the return type of the call
		// Example: this.applianceStateBehavior =
		// this.applianceStateBehavior.turnOn();

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.Appliance
	 * #turnOff()
	 */

	public override void turnOff(){// throws ApplianceCommunicationException {
		// TODO: Delegate to the the current ApplianceStateBehavior and set
		// this.applianceStateBehavior to the return type of the call
		// Example: this.applianceStateBehavior =
		// this.applianceStateBehavior.turnOff();

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.Appliance
	 * #start()
	 */

	public override void start() {//throws ApplianceCommunicationException {
		// TODO: Delegate to the the current ApplianceStateBehavior and set
		// this.applianceStateBehavior to the return type of the call
		// Example: this.applianceStateBehavior =
		// this.applianceStateBehavior.start();

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.Appliance
	 * #stop()
	 */

	public override void stop() {//throws ApplianceCommunicationException {
		// TODO: Delegate to the the current ApplianceStateBehavior and set
		// this.applianceStateBehavior to the return type of the call
		// Example: this.applianceStateBehavior =
		// this.applianceStateBehavior.stop();
	}
}
}