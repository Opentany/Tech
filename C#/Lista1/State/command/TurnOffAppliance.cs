using System;
using State.appliance;

namespace State.command
{
    public class TurnOffAppliance : AbstractCommand {

	/**
	 * @param receiverAppliance
	 */
	public TurnOffAppliance(Appliance receiverAppliance) :base(receiverAppliance){
		//super(receiverAppliance);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.mediator.command.Command
	 * #execute()
	 */

	public override void execute(){//} throws CouldNotExecuteCommandException {

		try {
			this.receiverAppliance.turnOff();
		} catch (ApplianceCommunicationException e) {
			// Log it
			Console.WriteLine(e.ToString());//e.printStackTrace();
			// Ecapsulate exception
			throw new CouldNotExecuteCommandException(e/*.fillInStackTrace()*/);
		}

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.
	 * UndoableCommand#rollback()
	 */

	public override void rollback() {//}throws CouldNotRollbackCommandException {

		try {
			this.receiverAppliance.turnOn();
		} catch (ApplianceCommunicationException e) {
			// log it
			Console.WriteLine(e.ToString());//e.printStackTrace();
			// Encapsulate
			throw new CouldNotRollbackCommandException(e);
		}

	}

}
}