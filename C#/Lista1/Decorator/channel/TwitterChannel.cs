using System;

namespace Decorator.channel
{
    public class TwitterChannel : SocialChannel {

	public static readonly String NAME = "twitter";

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.structural.decorator.channel.
	 * SocialChannel#deliverMessage(java.lang.String)
	 */
	public void deliverMessage(String stringg) {
		// What to do??
		Console.WriteLine("Twitter: " + stringg);

	}

}
}