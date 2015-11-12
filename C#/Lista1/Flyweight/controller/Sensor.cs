using System;

namespace Flyweight.controller
{
    public interface Sensor
    {
        /**
         * @param ipAddress 
         * @return
         */
        String read(String ipAddress);
    }
}