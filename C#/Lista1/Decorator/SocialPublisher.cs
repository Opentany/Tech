using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.channel;

namespace Decorator
{
    public class SocialPublisher
    {

        private List<SocialChannel> channels;

        public SocialPublisher()
        {
            this.channels = createSocialChannelList();
        }

        /**
         * @param textMessage
         */
        public void publish(String textMessage) {
		//For each channels, deliver the message
            foreach (var channel in channels)
            {
                channel.deliverMessage(textMessage);
            }
		

	}

        /**
         * @return
         */
        public int getSocialChannelsCount()
        {
            return this.channels.Count;
        }

        /**
         * @param channel
         */
        public void addSocialChannel(SocialChannel channel)
        {
            this.channels.Add(channel);
        }

        /**
         * Factory method
         * 
         * @return
         */
        protected List<SocialChannel> createSocialChannelList()
        {

            return new List<SocialChannel>();
        }

        /**
         * @param channel
         * @return
         */
        public bool removeChannel(SocialChannel channel)
        {
            bool removed = false;
            if (this.channels.Contains(channel))
            {
                this.channels.Remove(channel);
                removed = true;
            }
            return removed;
        }
    }
}
