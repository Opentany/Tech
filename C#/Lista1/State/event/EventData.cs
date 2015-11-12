namespace State.@event
{
    public class EventData : Properties {

	
	private ApplianceEvent eventt;
	/**
	 * 
	 */
	private static final long serialVersionUID = -2704386523375451765L;
	public ApplianceEvent getEvent() {
		return eventt;
	}
	public void setEvent(ApplianceEvent eventt) {
		this.eventt = eventt;
	}

}
}