namespace State.command
{
    public class TurnOffAppliance extends AbstractCommand {

	/**
	 * @param receiverAppliance
	 */
	public TurnOffAppliance(Appliance receiverAppliance) {
		super(receiverAppliance);
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
			this.receiverAppliance.turnOff();
		} catch (ApplianceCommunicationException e) {
			// Log it
			e.printStackTrace();
			// Ecapsulate exception
			throw new CouldNotExecuteCommandException(e.fillInStackTrace());
		}

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.
	 * UndoableCommand#rollback()
	 */
	@Override
	public void rollback() throws CouldNotRollbackCommandException {

		try {
			this.receiverAppliance.turnOn();
		} catch (ApplianceCommunicationException e) {
			// log it
			e.printStackTrace();
			// Encapsulate
			throw new CouldNotRollbackCommandException(e);
		}

	}

}
}