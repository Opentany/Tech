namespace State.command
{
    public class CouldNotRollbackCommandException extends Exception {

	/**
	 * @param throwable
	 */
	public CouldNotRollbackCommandException(Throwable throwable) {
super(throwable);
	}

	/**
	 * 
	 */
	private static final long serialVersionUID = -6190465258172050836L;

}
}