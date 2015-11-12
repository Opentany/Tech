namespace State.command
{
    public interface UndoableCommand extends Command {
	
	
	/**
	 * Attempts to rollback the command execution
	 * @throws CouldNotRollbackCommandException
	 */
	void rollback() throws CouldNotRollbackCommandException;

}
}