using System;

namespace State.command
{
    public class CouldNotRollbackCommandException : Exception {

	/**
	 * @param throwable
	 */
	public CouldNotRollbackCommandException(Exception throwable) {
//super(throwable);
	}

	/**
	 * 
	 */
	private static readonly long serialVersionUID = -6190465258172050836L;

}
}