using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		for (SocialChannel channel : this.channels ) {
			channel.deliverMessage(textMessage);
		}

	}

        /**
         * @return
         */
        public int getSocialChannelsCount()
        {
            return this.channels.size();
        }

        /**
         * @param channel
         */
        public void addSocialChannel(SocialChannel channel)
        {
            this.channels.add(channel);
        }

        /**
         * Factory method
         * 
         * @return
         */
        protected List<SocialChannel> createSocialChannelList()
        {

            return new ArrayList<SocialChannel>();
        }

        /**
         * @param channel
         * @return
         */
        public boolean removeChannel(SocialChannel channel)
        {
            boolean removed = false;
            if (this.channels.contains(channel))
            {
                this.channels.remove(channel);
                removed = true;
            }
            return removed;
        }
    }
}
