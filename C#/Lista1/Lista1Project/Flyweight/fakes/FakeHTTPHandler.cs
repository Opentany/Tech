//using System;
//using System.Threading;
//using Flyweight.dao;
//using Flyweight.model;
//using Flyweight.representations;
//using Flyweight.service;
//using Flyweight.transferobject;

//namespace UnitTesty.Flyweight.fakes
//{
//    public class FakeHTTPHandler : AbstractHandler{

//    /* (non-Javadoc)
//     * @see org.eclipse.jetty.server.Handler#handle(java.lang.String, org.eclipse.jetty.server.Request, javax.servlet.http.HttpServletRequest, javax.servlet.http.HttpServletResponse)
//     */
//    @Override
//    public void handle(String target, Request baseRequest, HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
//        String out = "Could not get weather";
//        //Get params
//        String city = request.getParameter("city");
//        String latitude = request.getParameter("la") ;
//        String longitude = request.getParameter("lo");
//        System.out.println("Thread: "+Thread.currentThread()+"Handling request for city: "+city);
//        System.out.println("Thread: "+Thread.currentThread()+"Handling request for latitude: "+latitude);
//        System.out.println("Thread: "+Thread.currentThread()+"Handling request for longitude: "+longitude);
		
//        if (city==null||latitude==null||longitude==null) {
//            out = "Please provide city, latitude and longitude. Ex ?city=aveiro&lo=111&la=232";
//        } else {
//            //Create the service
//            WeatherService service = createRestService();
//            WeatherReading reading = service.getWeatherReading(city, latitude, longitude);
//            if (reading != null) {
//                out = new JSONWeatherReading(reading).toString();
//            }

//        }

		
		
		
//        response.setContentType("text/html");
//        response.setStatus(HttpServletResponse.SC_OK);
//        response.getWriter().println(out);
//        ((Request)request).setHandled(true);
		
//    }

//    /**
//     * @return
//     */
//    private WeatherService createRestService() {
//        return new FakeWeatherService(createFakeDao());
//    }

//    /**
//     * @return
//     */
//    private Dao<City> createFakeDao() {

//        return new FakeCityDao();
//    }

//}
//}