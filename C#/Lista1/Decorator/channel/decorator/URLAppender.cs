using System;
using System.Text;

namespace Decorator.channel.decorator
{
    public class URLAppender : SocialChannelDecorator {

	private String url;

	/**
	 * @param url
	 */
	public URLAppender(String url) {
		this.url = url;
	}

	/**
	 * @param string
	 * @param channel
	 */
	public URLAppender(String url, SocialChannel channel) {
		this.url = url;
		this.delegateer = channel;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see eu.jpereira.trainings.designpatterns.structural.decorator.channel.
	 * SocialChannel#deliverMessage(java.lang.String)
	 */

	public override void deliverMessage(String message) {
		StringBuilder builder = new StringBuilder();
		builder.Append(message);
		builder.Append(" ");
		builder.Append(this.url);
		if (delegateer != null) {
			delegateer.deliverMessage(builder.ToString());
		}

	}

}
}