namespace State.@event
{
    public class EventData  {

	
	private ApplianceEvent eventt;
	/**
	 * 
	 */
	private static readonly long serialVersionUID = -2704386523375451765L;
	public ApplianceEvent getEvent() {
		return eventt;
	}
	public void setEvent(ApplianceEvent eventt) {
		this.eventt = eventt;
	}

        public string getProperty(string appliancemacaddress)
        {
            return appliancemacaddress;
        }
    }
}