using System;
using System.Collections.Generic;
using Decorator.channel.decorator;

namespace Decorator.channel
{
    public abstract class SocialChannelBuilder<T> {

	private Dictionary<String, SocialChannel> cachedChannels;
	
	// Map <name
	private Dictionary<String, T> pluggedChannels;

	private Stack<SocialChannelDecorator> decorators;
	
	//private List<SocialChannelDecorator> decorators;
	
	
	public SocialChannelBuilder() {
		this.pluggedChannels = createChannelsList<T>();
		this.cachedChannels = createChachedChannedlList();
		this.decorators = createDecoratorStack();
		this.addDefaultChannels();
	}

	/**
	 * Build a default list off channels. Others can be plugged either by
	 * extending this class and calling the method plugChannel() in constructor,
	 * for example;
	 */
	protected abstract void addDefaultChannels();

	/**
	 * @return
	 */
	protected Dictionary<String, X> createChannelsList<X>() {
		return new Dictionary<String, X>();
	}

	/**
	 * Factory method
	 */
	protected Dictionary<String, SocialChannel> createChachedChannedlList() {
		return new Dictionary<string, SocialChannel>();

	}

	/**
	 * Find an appropriate channel according to the properties
	 * 
	 * @param channelProperties
	 * @return
	 */
	public SocialChannel buildChannel(SocialChannelProperties channelProperties) {

		// lookup channel by name
		SocialChannel instance = null;

		String channelName = channelProperties.getProperty(SocialChannelPropertyKey.NAME);
	    if (channelName != null && this.pluggedChannels.ContainsKey(channelName))
	    {

	        // Try the cache
	        instance = this.cachedChannels[channelName];
			if (instance == null) {
				instance = instantiateChannel(this.pluggedChannels[channelName]);
				this.cachedChannels.Add(channelName, instance);
			}

		}

		return instance;
	}

	/**
	 * @param claszz
	 * @return
	 */
	private SocialChannel instantiateChannel(T claszz) {
		T instance = default(T);
		try {
			 instance = (T)Activator.CreateInstance();
		} catch (InstantiationException e) {
			// Just log it
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			// just log it
			e.printStackTrace();
		}
		return (SocialChannel)instance;
	}

	/**
	 * @param put
	 * @param clazz
	 */
	protected void plugChannel(SocialChannelProperties put, Class<? extends SocialChannel> clazz) {
		this.pluggedChannels.put(put.getProperty(SocialChannelPropertyKey.NAME), clazz);

	}


	/**
	 * @return
	 */
	protected Stack<SocialChannelDecorator> createDecoratorStack() {
		return new Stack<SocialChannelDecorator>();
	}

	
	/**
	 * @param messageTruncator
	 * @return
	 */
	public SocialChannelBuilder with(SocialChannelDecorator decorator) {
		this.decorators.push(decorator);
		return this;
	}

	/**
	 * @param props 
	 * @return
	 */
	public SocialChannel getDecoratedChannel(SocialChannelProperties props) {

		SocialChannel aSocialChannel = buildChannel(props);
		
		while ( !this.decorators.isEmpty() ) {
			SocialChannelDecorator aDecorator = this.decorators.pop();
			aDecorator.setDecoratedSocialChannel(aSocialChannel);
			aSocialChannel = aDecorator;
		}
		return aSocialChannel;
	}

	/**
	 * @param channel
	 * @return
	 */
	public SocialChannelBuilder andWith(MessageTruncator channel) {
		return with(channel);
	}

}
}