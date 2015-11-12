using System;
using State.appliance;

namespace State.command
{
    public class StartApplianceCommand : AbstractCommand {

	/**
	 * @param appliance
	 */
	public StartApplianceCommand(Appliance appliance):base(appliance) {
		//super(appliance);

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.mediator.command.Command
	 * #execute()
	 */

	public override void execute(){// throws CouldNotExecuteCommandException {
		try {
			this.receiverAppliance.start();
		} catch (ApplianceCommunicationException e) {
			// Log it
			Console.WriteLine(e.ToString());
			// encapsulate exception
			throw new CouldNotExecuteCommandException(e/*e.fillInStackTrace*/);
		}

	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.UndoableCommand#rollback()
	 */
	public override void rollback(){// throws CouldNotRollbackCommandException {
		
		try {
			this.receiverAppliance.stop();
		} catch (ApplianceCommunicationException e) {
			// Log it
			Console.WriteLine(e.ToString());
		    throw new CouldNotRollbackCommandException(e); /*e.fillInStackTrace*/
		}
		
		
	}

}
}