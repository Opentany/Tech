//using System;
//using State.appliance;
//using State.appliance.state;

//namespace UnitTesty.StateTest.fakes
//{
//    public class FakeApplianceDAO implements ApplianceDAO {

//    static Map<String, Appliance> appliances = new HashMap<String, Appliance>();
	
//    static {
//        Appliance toaster = new Toaster(ApplianceState.OFF);
//        toaster.setIpAddress("12.12.12.12");
//        toaster.setMacAddress("AA.BB.CC");
//        appliances.put(toaster.getMacAddress(), toaster);

//    }
//    /* (non-Javadoc)
//     * @see eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.dao.ApplianceDAO#findByMacAddress(java.lang.String)
//     */
//    @Override
//    public Appliance findByMacAddress(String macAddress) {
		
//        return appliances.get(macAddress);
//    }

//}
//}