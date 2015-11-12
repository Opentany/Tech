namespace State.command
{
    public class StopApplianceCommand extends AbstractCommand {

	/**
	 * @param appliance
	 */
	public StopApplianceCommand(Appliance appliance) {
		super(appliance);

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.mediator.command.Command
	 * #execute()
	 */
	@Override
	public void execute() throws CouldNotExecuteCommandException {
		try {
			this.receiverAppliance.stop();
		} catch (ApplianceCommunicationException e) {
			// log it
			e.printStackTrace();
			// Encapsulate
			throw new CouldNotExecuteCommandException(e.fillInStackTrace());
		}

	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.UndoableCommand#rollback()
	 */
	@Override
	public void rollback() throws CouldNotRollbackCommandException {
		
		try {
			this.receiverAppliance.start();
		} catch (ApplianceCommunicationException e) {
			// log it
			e.printStackTrace();
			//Encapsulate
			throw new CouldNotRollbackCommandException(e);
		}
		
		
	}

}
}