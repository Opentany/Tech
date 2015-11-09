namespace Decorator.channel.decorator
{
    public abstract class SocialChannelDecorator : SocialChannel {

	protected SocialChannel delegateer;
	
	/**
	 * @param decoratedChannel
	 */
	public void setDecoratedSocialChannel(SocialChannel decoratedChannel) {
		this.delegateer = decoratedChannel;
	}

        public virtual void deliverMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}