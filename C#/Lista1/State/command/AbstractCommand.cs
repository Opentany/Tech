using State.appliance;
using State.appliance.snapshot;

namespace State.command
{
    public abstract class AbstractCommand implements UndoableCommand {

	protected Appliance receiverAppliance = null;
	
	protected Map<Command, Snapshot> snapshots;

	protected AbstractCommand(Appliance appliance) {
		this.receiverAppliance = appliance;
		this.snapshots = createSnapshots();
	}

	/**
	 * factory method
	 * @return
	 */
	protected  Map<Command, Snapshot> createSnapshots() {
		return new HashMap<Command, Snapshot>();
	}
}
}