namespace State.command
{
    public interface Command {

	
	/**
	 * Ececute the command
	 * @throws CouldNotExecuteCommandException If the command fails to execute
	 */
        void execute();//throws CouldNotExecuteCommandException;
	
}
}