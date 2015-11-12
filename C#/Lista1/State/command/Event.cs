using System.Collections;
using System.Collections.Generic;

namespace State.command
{
    public class Event : UndoableCommand, IEnumerable<Command>
    {

	// Back list
	private List<Command> commands;

	private Stack<Command> executedCommands;

	public Event() {
		this.commands = createCommandList();
		this.executedCommands = createSucceedCommand();
	}

	/**
	 * Adds a new command to be executed in this event's execute()
	 * 
	 * @param command
	 */
	public void addCommand(Command command) {
		this.commands.Add(command);
	}

	public void removeCommand(Command command) {
		this.commands.Remove(command);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.mediator.command.Command
	 * #execute()
	 */

	public void execute() {//throws CouldNotExecuteCommandException {
        //for (Command command : commands) {
        //    this.executedCommands.push(command);
        //    command.execute();
			

        //}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.lang.Iterable#iterator()
	 */

	public List<Command>.Enumerator enumerator()
	{
	    return this.commands.GetEnumerator();
	}

	/**
	 * Create the list of commands
	 * 
	 * @return
	 */
	protected List<Command> createCommandList() {
		return new List<Command>();
	}

	/**
	 * Factory method
	 * 
	 * @return
	 */
	protected Stack<Command> createSucceedCommand() {

		return new Stack<Command>();
	}

	/**
	 * @param command
	 *            an array of commands
	 * @return
	 */
	public Event with(params Command[] command) {

		this.commands.AddRange(command);
		return this;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.behavioral.mediator.command.
	 * UndoableCommand#rollback()
	 */

	public void rollback(){// throws CouldNotRollbackCommandException {
		while ( executedCommands.Count!=0) {
			Command command = executedCommands.Pop();
			if (command.GetType().IsAssignableFrom(typeof(UndoableCommand))) {
				((UndoableCommand)(command)).rollback();
			}
		}

	}

        public IEnumerator<Command> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}