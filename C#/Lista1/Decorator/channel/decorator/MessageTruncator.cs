using System;
using System.Text;

namespace Decorator.channel.decorator
{
    public class MessageTruncator : SocialChannelDecorator {

	private int maxLength = 0;

	/**
	 * @param maxLength
	 */
	public MessageTruncator(int maxLength) {
		this.maxLength = maxLength;
	}

	/**
	 * @param i
	 * @param decoratedChannel
	 */
	public MessageTruncator(int i, SocialChannel decoratedChannel) {
		this.maxLength = i;
		this.delegateer = decoratedChannel;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.structural.decorator.channel.
	 * SocialChannel#deliverMessage(java.lang.String)
	 */

	public override void deliverMessage(String message) {
		if (message.Length > maxLength) {
			StringBuilder builder = new StringBuilder();
			builder.Append(message.Substring(0, maxLength - 3));
			builder.Append("...");
			message = builder.ToString();
		}
		delegateer.deliverMessage(message);

	}

}
}