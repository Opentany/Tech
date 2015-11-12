//using System;
//using Flyweight.controller;
//using Flyweight.dao;
//using Flyweight.model;
//using Flyweight.service;
//using Flyweight.transferobject;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTesty.Flyweight
//{
//    [TestClass]
//    public class WeatherServiceTest {

//    private CityDao mockedCityDao;
//    private City mockedCity;
//    private WeatherStation mockedWeatherStation;
//    private WeatherStationController mockedWeatherStationController;

//    @Test
//    public void testGetWeatherReading() {
//        WeatherService service = createWeatherService();
//        // City dao will be called to get

//        String city = "aveiro";
//        String dummyLatitude = "1232";
//        String dummyLongitude = "332";

//        // stub returns
//        when(mockedCityDao.findBy("city", city)).thenReturn(mockedCity);
//        when(mockedCity.findNearestStation(dummyLatitude, dummyLongitude)).thenReturn(mockedWeatherStation);
//        //when(mockedWeatherStation.getControler()).thenReturn(mockedWeatherStationController);

		
//        when(mockedWeatherStationController.getHumidityValue("22.22.22.22")).thenReturn("22");
//        when(mockedWeatherStationController.getTemperatureValue("22.22.22.22")).thenReturn("22");
//        when(mockedWeatherStationController.getWindValue("22.22.22.22")).thenReturn("22");

//        WeatherReading reading = service.getWeatherReading(city, dummyLatitude, dummyLongitude);
//        assertNotNull(reading);
//    }

//    /**
//     * @return
//     */
//    private WeatherService createWeatherService() {

//        mockedCity = mock(City.class);
//        mockedCityDao = mock(CityDao.class);
//        mockedWeatherStation = mock(WeatherStation.class);
//        mockedWeatherStationController = mock(WeatherStationController.class);

//        WeatherService service = new FakeWeatherService(mockedCityDao);
//        return service;
//    }

//}
//}
