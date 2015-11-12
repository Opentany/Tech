//using System;
//using Flyweight.controller;

//namespace UnitTesty.Flyweight.fakes
//{
//    public class FakeWeatherStationControllerFactory implements WeatherStationControllerFactory {

//    private static volatile WeatherStationControllerFactory instance = null;
//    private Map<String, WeatherStationController> controllers;

//    // TODO: Remove this variable

//    protected FakeWeatherStationControllerFactory() {
//        this.controllers = new HashMap<String, WeatherStationController>();
//    }

//    /**
//     * @return
//     */
//    public static WeatherStationControllerFactory instance() {
//        if (instance == null) {
//            synchronized (FakeWeatherStationControllerFactory.class) {
//                if (instance == null) {
//                    instance = new FakeWeatherStationControllerFactory();
//                }
//            }
//        }
//        return instance;
//    }

//    /*
//     * (non-Javadoc)
//     * 
//     * @see
//     * eu.jpereira.trainings.designpatterns.creational.flyweight.controller.
//     * WeatherStationControllerFactory#getController(java.lang.String)
//     */
//    @Override
//    public synchronized WeatherStationController getController(String ipAddress) {
//        WeatherStationController controller = null;
//        /*
//        //Try to get from the map of available instances of controller
//        WeatherStationController controller = this.controllers.get(ipAddress);
//        //If does not exists, create it
//        if (controller == null) {
			
//            controller = new FakeWeatherStationController(new TemperatureSensor(), new HumiditySensor(), new WindSensor());
//            this.controllers.put(ipAddress, controller);

//        }*/
//        return controller;
//    }

//}
//}