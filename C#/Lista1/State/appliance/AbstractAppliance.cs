using System;
using State.appliance.snapshot;
using State.appliance.state;

namespace State.appliance
{
    public abstract class AbstractAppliance : Appliance {

	protected ApplianceStateBehavior applianceStateBehavior = null;
	protected String ipAddress;
	protected String macAddress;

	public AbstractAppliance()
    { }
	public AbstractAppliance(ApplianceState initialState)
	{
	    //this.applianceStateBehavior = initialState //.getStateBehavior();
	}
	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.Appliance
	 * #setIpAddress(java.lang.String)
	 */
        public virtual void turnOn()
        {
            throw new NotImplementedException();
        }

        public virtual void turnOff()
        {
            throw new NotImplementedException();
        }

        public virtual void start()
        {
            throw new NotImplementedException();
        }

        public virtual void stop()
        {
            throw new NotImplementedException();
        }

        public void setIpAddress(String ipAddress) {
		this.ipAddress = ipAddress;

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.Appliance
	 * #setMacAddress(java.lang.String)
	 */

	public void setMacAddress(String macAddress) {
		this.macAddress = macAddress;

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.behavioral.observer.appliance.Appliance
	 * #getMacAddress()
	 */

	public String getMacAddress() {
		return this.macAddress;
	}


	public Object getIpAddress() {

		return this.ipAddress;
	}

	public ApplianceState getState() {
		return this.applianceStateBehavior.getState();
	}


        public virtual Snapshot takeSnapshot()
        {
            throw new NotImplementedException();
        }

        public virtual void restoreFromSnapshot(Snapshot snapshot)
        {
            throw new NotImplementedException();
        }
    }
}