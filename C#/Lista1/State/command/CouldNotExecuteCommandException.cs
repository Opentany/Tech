namespace State.command
{
    public class CouldNotExecuteCommandException extends Exception {

	/**
	 * @param fillInStackTrace
	 */
	public CouldNotExecuteCommandException(Throwable throwable) {
		super(throwable);
	}

	/**
	 * 
	 */
	private static final long serialVersionUID = -7531282976902475900L;

}
}