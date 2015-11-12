using System;

namespace State.command.director
{
    public class ErrorDirectingCommandsException : Exception {

	/**
	 * @param stacktrace
	 */
	public ErrorDirectingCommandsException(Exception stacktrace) {
		//super(stacktrace); //?
	}

	/**
	 * 
	 */
	private static readonly long serialVersionUID = 1561118747196226584L;

}
}