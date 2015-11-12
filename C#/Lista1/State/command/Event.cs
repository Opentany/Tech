namespace State.command
{
    public class Event implements UndoableCommand, Iterable<Command> {

	// Back list
	private List<Command> commands;

	private Stack<Command> executedCommands;

	public Event() {
		this.commands = createCommandList();
		this.executedCommands = createSucceedCommand();
	}

	/**
	 * Adds a new command to be executed in this event's execute()
	 * 
	 * @param command
	 */
	public void addCommand(Command command) {
		this.commands.add(command);
	}

	public void removeCommand(Command command) {
		this.commands.remove(command);
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
		for (Command command : commands) {
			this.executedCommands.push(command);
			command.execute();
			

		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.lang.Iterable#iterator()
	 */
	@Override
	public Iterator<Command> iterator() {
		return this.commands.iterator();
	};

	/**
	 * Create the list of commands
	 * 
	 * @return
	 */
	protected List<Command> createCommandList() {
		return new ArrayList<Command>();
	}

	/**
	 * Factory method
	 * 
	 * @return
	 */
	protected Stack<Command> createSucceedCommand() {

		return new Stack<Command>();
	}

	/**
	 * @param command
	 *            an array of commands
	 * @return
	 */
	public Event with(Command... command) {

		this.commands.addAll(Arrays.asList(command));
		return this;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.
	 * UndoableCommand#rollback()
	 */
	@Override
	public void rollback() throws CouldNotRollbackCommandException {
		while ( !executedCommands.isEmpty()) {
			Command command = executedCommands.pop();
			if (command instanceof UndoableCommand) {
				((UndoableCommand)(command)).rollback();
			}
		}

	}

}
}