namespace State.command.director
{
    public class ErrorDirectingCommandsException extends Exception {

	/**
	 * @param stacktrace
	 */
	public ErrorDirectingCommandsException(Throwable stacktrace) {
		super(stacktrace);
	}

	/**
	 * 
	 */
	private static final long serialVersionUID = 1561118747196226584L;

}
}