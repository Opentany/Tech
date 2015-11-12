using System;

namespace Flyweight.model
{
    public class WeatherStation
    {


        private String ipAddress;
        private String latitude;
        private String longitude;
        public WeatherStation(String ipAddress, String latitude, String longitude)
        {
            this.ipAddress = ipAddress;
            this.setLatitude(latitude);
            this.longitude = longitude;
        }

        public String getLatitude()
        {
            return latitude;
        }
        protected void setLatitude(String latitude)
        {
            this.latitude = latitude;
        }
        public String getIpAddress()
        {
            return ipAddress;
        }
        protected void setIpAddress(String ipAddress)
        {
            this.ipAddress = ipAddress;
        }
        public String getLongitude()
        {
            return longitude;
        }
        protected void setLongitude(String longitude)
        {
            this.longitude = longitude;
        }

    }
}