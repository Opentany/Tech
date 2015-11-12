namespace State.command
{
    public class StartApplianceCommand extends AbstractCommand {

	/**
	 * @param appliance
	 */
	public StartApplianceCommand(Appliance appliance) {
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
			this.receiverAppliance.start();
		} catch (ApplianceCommunicationException e) {
			// Log it
			e.printStackTrace();
			// encapsulate exception
			throw new CouldNotExecuteCommandException(e.fillInStackTrace());
		}

	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.UndoableCommand#rollback()
	 */
	@Override
	public void rollback() throws CouldNotRollbackCommandException {
		
		try {
			this.receiverAppliance.stop();
		} catch (ApplianceCommunicationException e) {
			// Log it
			e.printStackTrace();
			throw new CouldNotRollbackCommandException(e.fillInStackTrace());
		}
		
		
	}

}
}