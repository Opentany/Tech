using State.appliance;
using State.appliance.dao;
using State.@event;

namespace State.mapper
{
    public class ApplianceEventMapper implements EventMapper {

	private ApplianceDAO applianceDao = null;

	/**
	 * @param applianceDAO
	 */
	public ApplianceEventMapper(ApplianceDAO applianceDAO) {
		this.applianceDao = applianceDAO;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.mapper.EventMapper
	 * #doMap(eu.jpereira.trainings.designpatterns.behavioral.observer.event.
	 * EventData,
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.event.
	 * ApplianceEvent,
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.mapper
	 * .MapperChain)
	 */
	@Override
	public void doMap(EventData data, MapperChain chain) {
		
		
		//If event is null or event.sourceAppliance is null, create new one
		if ( data.getEvent() ==null) {

			data.setEvent( new ApplianceEvent(null));
		}
		if (data.getEvent().getSourceAppliance()==null) {
			//Find the right appliance in the DAO
			Appliance appliance = applianceDao.findByMacAddress(data.getProperty("applianceMacAddress"));
			data.getEvent().setSourceAppliance(appliance);
			
		}
		
		chain.doMap(data);

	}

}
}