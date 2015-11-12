using System;

namespace Flyweight.controller
{
    public abstract class WeatherStationController
    {

        private Sensor temperatureSensor;
        private Sensor humiditySensor;
        private Sensor windSensor;

        /**
         * 
         * @param temperatureSensor
         * @param humiditySensor
         * @param windSensor
         */
        public WeatherStationController(TemperatureSensor temperatureSensor, HumiditySensor humiditySensor, WindSensor windSensor)
        {
            this.humiditySensor = humiditySensor;
            this.temperatureSensor = temperatureSensor;
            this.windSensor = windSensor;
        }

        /**
         * @return
         */
        public String getTemperatureValue(String ipAddress)
        {
            return this.temperatureSensor.read(ipAddress);
        }

        /**
         * @return
         */
        public String getHumidityValue(String ipAddress)
        {
            return this.humiditySensor.read(ipAddress);
        }

        /**
         * @return
         */
        public String getWindValue(String ipAddress)
        {
            return this.windSensor.read(ipAddress);
        }

    }
}