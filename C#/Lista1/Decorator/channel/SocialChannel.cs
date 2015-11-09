using System;

namespace Decorator.channel
{
    public interface SocialChannel
    {

        /**
         * @param message
         */
        void deliverMessage(String message);


    }
}