using System;

namespace Flyweight.transferobject
{
    public class WeatherReading
    {
        private String temperature;
        private String humidity;
        private String wind;

        /**
         * @param temperature
         * @param humidity
         * @param wind
         */

        public WeatherReading(String temperature, String humidity, String wind)
        {
            this.setTemperature(temperature);
            this.setHumidity(humidity);
            this.setWind(wind);
        }

        public String getTemperature()
        {
            return temperature;
        }

        protected void setTemperature(String temperature)
        {
            this.temperature = temperature;
        }

        public String getHumidity()
        {
            return humidity;
        }

        protected void setHumidity(String humidity)
        {
            this.humidity = humidity;
        }

        public String getWind()
        {
            return wind;
        }

        protected void setWind(String wind)
        {
            this.wind = wind;
        }
    }
}