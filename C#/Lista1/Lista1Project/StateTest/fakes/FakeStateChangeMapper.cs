namespace UnitTesty.StateTest.fakes
{
    public class FakeStateChangeMapper implements EventMapper {

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
		if (data.getEvent() == null || data.getEvent().getSourceAppliance() == null) {
			throw new IllegalStateException("Must run any mapper before this in order to fill the event with the righjt appliance");
		}
		
		
		if (data.getProperty("type").equals("stateChange")) {
			StateChangeEvent event = createStateChangeEvent(data);
			data.setEvent(event);
		}

		chain.doMap(data);

	}

	/**
	 * @param data
	 * @return
	 */
	private StateChangeEvent createStateChangeEvent(EventData data) {
		// TODO Auto-generated method stub
		AttributeChangeEvent event = new AttributeChangeEvent(data.getEvent().getSourceAppliance());
		
		return event;
	}

}
}