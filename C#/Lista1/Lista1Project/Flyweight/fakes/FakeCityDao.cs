//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Flyweight.dao;
//using Flyweight.model;

//namespace UnitTesty.Flyweight.fakes
//{
//    public class FakeCityDao : Dao<City> {

//    // dummy in Memory DB
//        private static Dictionary<String, City> cities = new Dictionary<string, City>();

//    //static {
//        // add a dummy overrided city

//        private static City aveiro = new City();

//            private static String latitude = "222";
//            private static String longitude ="22";
//            private static String ipAddress ="22.22.22.22";


//            static WeatherStation station = new WeatherStation(ipAddress,latitude,longitude);

//        public static WeatherStation findNearestStation(String latitude, String longitude)
//        {
//            // Create allways the same

//            return station;
//        }
    

//        cities.put("aveiro", aveiro);//??
       
    

//    /*
//     * (non-Javadoc)
//     * 
//     * @see
//     * eu.jpereira.trainings.designpatterns.creational.flyweight.dao.Dao#findBy
//     * (java.lang.String, java.lang.String)
//     */

//    public City findBy(String property, String value) {
//        // See for each property where it should look from
//        var myValue = cities.FirstOrDefault(x => x.Value.ToString() == value).Key;
//        return cities[myValue];

//    }

//}
//}