using System;
using System.Text;
using Flyweight.transferobject;

namespace Flyweight.representations
{
    public class JSONWeatherReading
    {
        private WeatherReading weatherReading;

        /**
	 * @param weatherReading
	 */

        public JSONWeatherReading(WeatherReading weatherReading)
        {
            this.weatherReading = weatherReading;
        }


        public override String ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("temp: ");
            builder.Append("\"");
            builder.Append(weatherReading.getTemperature());
            builder.Append("\"");

            builder.Append(",hum: ");
            builder.Append("\"");
            builder.Append(weatherReading.getHumidity());
            builder.Append("\"");

            builder.Append(",wind: ");
            builder.Append("\"");
            builder.Append(weatherReading.getWind());
            builder.Append("\"}");

            return builder.ToString();
        }
    }
}