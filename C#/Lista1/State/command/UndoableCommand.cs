namespace State.command
{
    public interface UndoableCommand : Command {
	
	
	/**
	 * Attempts to rollback the command execution
	 * @throws CouldNotRollbackCommandException
	 */
        void rollback();// throws CouldNotRollbackCommandException;

}
}