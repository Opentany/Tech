using System;
using State.appliance;

namespace State.command
{
    public class TurnOnApplianceCommand : AbstractCommand  {

	
	/**
	 * @param appliance
	 */
	public TurnOnApplianceCommand(Appliance appliance):base(appliance) {
		//super(appliance);
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.Command#execute()
	 */

	public override void execute() {//} throws CouldNotExecuteCommandException {
		try {
			this.receiverAppliance.turnOn();
		} catch (ApplianceCommunicationException e) {
			//Log
			Console.WriteLine(e.ToString());//e.printStackTrace();
			//encapsulate exception
			throw new CouldNotExecuteCommandException(e/*.fillInStackTrace()*/);
		}
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.UndoableCommand#rollback()
	 */

	public override void rollback() {//}throws CouldNotRollbackCommandException {

		try {
			this.receiverAppliance.turnOff();
		} catch (ApplianceCommunicationException e) {
			// log it
			Console.WriteLine(e.ToString());//e.printStackTrace();
			//Encapsulate
			throw new CouldNotRollbackCommandException(e);
		}
		
	}

}
}