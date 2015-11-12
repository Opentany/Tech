namespace State.command
{
    public class TurnOnApplianceCommand extends AbstractCommand  {

	
	/**
	 * @param appliance
	 */
	public TurnOnApplianceCommand(Appliance appliance) {
		super(appliance);
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.Command#execute()
	 */
	@Override
	public void execute() throws CouldNotExecuteCommandException {
		try {
			this.receiverAppliance.turnOn();
		} catch (ApplianceCommunicationException e) {
			//Log
			e.printStackTrace();
			//encapsulate exception
			throw new CouldNotExecuteCommandException(e.fillInStackTrace());
		}
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.UndoableCommand#rollback()
	 */
	@Override
	public void rollback() throws CouldNotRollbackCommandException {

		try {
			this.receiverAppliance.turnOff();
		} catch (ApplianceCommunicationException e) {
			// log it
			e.printStackTrace();
			//Encapsulate
			throw new CouldNotRollbackCommandException(e);
		}
		
	}

}
}