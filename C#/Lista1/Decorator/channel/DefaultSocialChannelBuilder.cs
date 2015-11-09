namespace Decorator.channel
{
    public class DefaultSocialChannelBuilder : SocialChannelBuilder
    {

	protected override void addDefaultChannels() {
		super.plugChannel(new SocialChannelProperties().putProperty(SocialChannelPropertyKey.NAME, TwitterChannel.NAME), TwitterChannel.class);
		super.plugChannel(new SocialChannelProperties().putProperty(SocialChannelPropertyKey.NAME, FacebookChannel.NAME), FacebookChannel.class);
		super.plugChannel(new SocialChannelProperties().putProperty(SocialChannelPropertyKey.NAME, LinkedinChannel.NAME), LinkedinChannel.class);
		
	}
}
}