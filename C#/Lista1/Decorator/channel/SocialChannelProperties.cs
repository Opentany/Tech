using System;
using System.Collections.Generic;

namespace Decorator.channel
{
    public class SocialChannelProperties
    {

        private Dictionary<SocialChannelPropertyKey, String> props;

        /**
         * 
         */
        public SocialChannelProperties()
        {
            this.props = new Dictionary<SocialChannelPropertyKey, String>();
        }

        /**
         * @param key
         * @param propValue
         */
        public SocialChannelProperties putProperty(SocialChannelPropertyKey key, String propValue)
        {
            this.props.Add(key, propValue);
            return this;

        }

        /**
         * @param key
         * @return
         */
        public String getProperty(SocialChannelPropertyKey key)
        {
            return this.props[key];
        }
    }
}