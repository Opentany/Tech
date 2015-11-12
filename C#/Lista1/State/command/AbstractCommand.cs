using System.Collections.Generic;
using State.appliance;
using State.appliance.snapshot;

namespace State.command
{
    public abstract class AbstractCommand : UndoableCommand {

	protected Appliance receiverAppliance = null;
	
	protected Dictionary<Command, Snapshot> snapshots;
    protected AbstractCommand() { }
	protected AbstractCommand(Appliance appliance) {
		this.receiverAppliance = appliance;
		this.snapshots = createSnapshots();
	}

	/**
	 * factory method
	 * @return
	 */
	protected  Dictionary<Command, Snapshot> createSnapshots() {
		return new Dictionary<Command, Snapshot>();
	}

        public virtual void execute()
        {
            throw new System.NotImplementedException();
        }

        public virtual void rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}