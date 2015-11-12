using System;
using Flyweight.transferobject;

namespace Flyweight.service
{
    public interface WeatherService
    {
        /**
         * @param city
         * @param dummyLatitude
         * @param dummyLongitude
         * @return
         */
        WeatherReading getWeatherReading(String city, String dummyLatitude, String dummyLongitude);
    }
}