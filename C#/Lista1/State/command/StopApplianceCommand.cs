using System;
using State.appliance;

namespace State.command
{
    public class StopApplianceCommand : AbstractCommand {

	/**
	 * @param appliance
	 */
	public StopApplianceCommand(Appliance appliance):base(appliance) {
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
			this.receiverAppliance.stop();
		} catch (ApplianceCommunicationException e) {
			// log it
			Console.WriteLine(e.ToString());//e.printStackTrace();
			// Encapsulate
			throw new CouldNotExecuteCommandException(e/*.fillInStackTrace()*/);
		}

	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.UndoableCommand#rollback()
	 */

	public override void rollback(){//}throws CouldNotRollbackCommandException {
		
		try {
			this.receiverAppliance.start();
		} catch (ApplianceCommunicationException e) {
			// log it
			Console.WriteLine(e.ToString());//e.printStackTrace();
			//Encapsulate
			throw new CouldNotRollbackCommandException(e);
		}
		
		
	}

}
}