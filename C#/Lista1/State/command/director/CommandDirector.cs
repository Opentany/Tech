namespace State.command.director
{
    public interface CommandDirector {

	/**
	 * Set the strategy for when some command in the director fails to execute
	 * 
	 * @param stategy
	 */
	void setFailStrategy(FailStategy stategy);

	/**
	 * Will execute all commands according to the {@link FailStategy} set in
	 * {@link CommandDirector#setFailStrategy(FailStategy)}
	 * 
	 * @throws ErrorDirectingCommandsException
	 *             Encapsulates any error occurring in the process
	 */
        void run();// throws ErrorDirectingCommandsException;

	/**
	 * Will add all commands to the list of commands to direct.
	 * If an command in undoable, them will try to rollback the command after command failure
	 * @param command A Command
	 * @param commands Array of commands. 
	 */
	void addCommand(Command command ,params Command[] commands);
}
}