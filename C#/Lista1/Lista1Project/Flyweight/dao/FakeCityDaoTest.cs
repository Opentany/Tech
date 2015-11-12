//using System;
//using Flyweight.dao;
//using Flyweight.model;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using UnitTesty.Flyweight.fakes;

//namespace UnitTesty.Flyweight.dao
//{
//    [TestClass]
//    public class FakeCityDaoTest {

	
//    [TestMethod]
//    public void testGetCity() {
//        //Create test dao
//        Dao<City> dao = createTestDao();
		
//        String cityName = "aveiro";
//        Assert.IsNotNull(dao.findBy("name", cityName));
//        Assert.IsNotNull(dao.findBy("name", cityName).findNearestStation("111", "112"));
		
//        Assert.IsNotNull(dao.findBy("name", cityName).findNearestStation("111", "112").getIpAddress());
		
				
		
		
//    }

//    /**
//     * @return
//     */
//    private Dao<City> createTestDao() {

//        return new FakeCityDao();
//    }
	
//}
//}
