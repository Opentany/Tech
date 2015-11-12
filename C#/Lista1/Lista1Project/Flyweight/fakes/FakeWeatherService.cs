//using System;
//using Flyweight.controller;
//using Flyweight.dao;
//using Flyweight.model;
//using Flyweight.transferobject;

//namespace UnitTesty.Flyweight.fakes
//{
//    public class FakeWeatherService implements WeatherService {

//    private Dao<City> dao;

//    /**
//     * @param dao
//     */
//    public FakeWeatherService(Dao<City> dao) {
//        this.dao = dao;
//    }

//    /*
//     * (non-Javadoc)
//     * 
//     * @see eu.jpereira.trainings.designpatterns.creational.flyweight.service.
//     * WeatherService#getWeatherReading(java.lang.String, java.lang.String,
//     * java.lang.String)
//     */
//    @Override
//    public WeatherReading getWeatherReading(String cityName, String latitude, String longitude) {

//        WeatherReading reading = null;
//        // Find the city
//        City city = dao.findBy("city", cityName);

//        if (city != null) {
//            // Lookup for the neareast station
//            WeatherStation station = city.findNearestStation(latitude, longitude);
//            if (station != null) {
//                String ipAddress = station.getIpAddress();
//                reading = readStationController(ipAddress);
//            }
//        }
//        return reading;
//    }

//    /**
//     * @param controller
//     * @return
//     */
//    private WeatherReading readStationController(String ipAddress) {
//        // TODO: Replace the instantiation of WeatherStationController with a
//        // factory call. Comment the instantiation and uncomment the factory call
		
//        // TODO:. Comment it
//        WeatherStationController controller = new FakeWeatherStationController(new TemperatureSensor(), new HumiditySensor(), new WindSensor());
		
//        //TODO: Uncomment it
//        //WeatherStationController controller = FakeWeatherStationControllerFactory.instance().getController(ipAddress);

//        String temperature = controller.getTemperatureValue(ipAddress);
//        String humidity = controller.getHumidityValue(ipAddress);
//        String wind = controller.getWindValue(ipAddress);
//        WeatherReading reading = new WeatherReading(temperature, humidity, wind);
//        return reading;
//    }

//}
//}