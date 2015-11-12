using System;

namespace Flyweight.controller
{
    public interface WeatherStationControllerFactory
    {

        /**
         * @param ipAddress
         * @return
         */
        WeatherStationController getController(String ipAddress);

    }
}