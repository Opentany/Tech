using System;

namespace State.command
{
    public class CouldNotExecuteCommandException : Exception {

	/**
	 * @param fillInStackTrace
	 */
	public CouldNotExecuteCommandException(Exception throwable) {
		//super(throwable);
	}

	/**
	 * 
	 */
	private static readonly long serialVersionUID = -7531282976902475900L;

}
}