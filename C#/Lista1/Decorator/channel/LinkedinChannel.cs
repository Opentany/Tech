using System;

namespace Decorator.channel
{
    public class LinkedinChannel implements SocialChannel {

	public static final String NAME = "linkedin";

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.structural.decorator.channel.
	 * SocialChannel#deliverMessage(java.lang.String)
	 */
	@Override
	public void deliverMessage(String string) {
		// What to do??
		System.out.println("LinkedIn: " + string);

	}

}
}