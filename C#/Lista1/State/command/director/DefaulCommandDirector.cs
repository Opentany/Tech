using System;
using System.Collections.Generic;

namespace State.command.director
{
    public class DefaulCommandDirector : CommandDirector {

	// Fail Strategy. It will define how the DirectorrWill fail. Should it try
	// to recover, ignore, fail-fast?
	protected FailStategy failStrategy;
	// The commands to be executed by this director
	protected List<Command> commands = null;
	// Stack maintaining the commands already executed. Used for rollback
	// operations
	private Stack<Command> executedCommands;

	/**
	 * Create new DefaultCommandDirector
	 */
	public DefaulCommandDirector() {
		// Use DEFAULT. Will do a rollback after a first command execution
		// failure
		this.failStrategy = FailStategy.DEFAULT;
		// Delegate instantiation to a factory method
		this.commands = createCommands();
		// Delegate instantiation to a factory method
		this.executedCommands = createExecutedStack();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.mediator.appliance.director
	 * .CommandDirector#setFailStrategy(eu.jpereira.trainings.designpatterns.
	 * behavioral.mediator.appliance.director.FailStategy)
	 */


	public void setFailStrategy(FailStategy strategy) {
		this.failStrategy = strategy;

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.mediator.appliance.director
	 * .CommandDirector#run()
	 */

	
	public void run() {// ErrorDirectingCommandsException {
        //for (Command command : this.commands) {

        //    try { // Push the command to the stack of executed commands
        //        executedCommands.push(command);
        //        command.execute();

        //    } catch (CouldNotExecuteCommandException e) { // Default strategy is
        //                                                    // to
        //        rollback();
        //        // Log
        //        e.printStackTrace();
        //        // abstract
        //        throw new ErrorDirectingCommandsException(e.fillInStackTrace());

        //    }
        //}
	    foreach (var command in this.commands)
	    {
            try
            { // Push the command to the stack of executed commands
                executedCommands.Push(command);
                command.execute();

            }
            catch (CouldNotExecuteCommandException e)
            { // Default strategy is
                // to
                rollback();
                // Log
                Console.WriteLine(e.ToString());//e.printStackTrace();
                // abstract
                throw new ErrorDirectingCommandsException(e);

            }
	    }

	}


        /*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.mediator.appliance.director
	 * .
	 * CommandDirector#addCommand(eu.jpereira.trainings.designpatterns.behavioral
	 * .mediator.command.Command,
	 * eu.jpereira.trainings.designpatterns.behavioral
	 * .mediator.command.Command[])
	 */

	
	public void addCommand(Command command,params Command[] commands) {
		this.commands.Add(command); // Add the Commands in the Arrsy of argument
									// commands to the list of commands to
									// execute
		if (commands != null && commands.Length > 0) {
			//this.commands.addAll(Arrays.asList(commands));
            this.commands.AddRange(commands);
		}
	}

	/**
	 * Rollback the command execution
	 */
	private void rollback() {
		while (executedCommands.Count != 0) {
			// Pop the last executed command....
			Command rollBackcommand = executedCommands.Pop();
            if (rollBackcommand.GetType().IsAssignableFrom(typeof(UndoableCommand)))
            {
				try {
					// Rollback it
					((UndoableCommand) rollBackcommand).rollback();
				} catch (CouldNotRollbackCommandException e) {
					// Ignore
					Console.WriteLine(e.ToString());//e.printStackTrace();
				}

			}
		}

	}

	/**
	 * Factory Method
	 * 
	 * @return
	 */
	protected Stack<Command> createExecutedStack() {
		return new Stack<Command>();
	}

	/**
	 * Factory method
	 * 
	 * @return
	 */
	protected List<Command> createCommands() {
		return new List<Command>();
	}

}
}