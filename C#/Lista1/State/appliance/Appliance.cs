using System;
using State.appliance.snapshot;
using State.appliance.state;

namespace State.appliance
{
    public interface Appliance : Snapshotable {

	/**
	 * Generic turnOn interface. Will turn on the Appliance to the AC Power This
	 * will turn the Appliance on
	 * 
	 * @throws ApplianceCommunicationExceptionIf
	 *             could not establish communication with the Appliance
	 */
        void turnOn(); //throws ApplianceCommunicationException;

	/**
	 * Generic Turn Off interface. Will turn off the Appliance from the AC Power
	 * Will turn the appliance OFF
	 * 
	 * @throws ApplianceCommunicationExceptionIf
	 *             could not establish communication with the Appliance
	 */
        void turnOff(); //throws ApplianceCommunicationException;

	/**
	 * Generic Start interface. Will start the function of the Appliance
	 * 
	 * @throws ApplianceCommunicationExceptionIf
	 *             could not establish communication with the Appliance
	 */
        void start();// throws ApplianceCommunicationException;

	/**
	 * Generic Stop interface. Will stop the function of the Appliance
	 * 
	 * @throws ApplianceCommunicationExceptionIf
	 *             could not establish communication with the Appliance
	 */
        void stop();// throws ApplianceCommunicationException;

	/**
	 * Set the IP Address of this {@link Appliance}
	 * @param string 
	 */
	void setIpAddress(String stringg);

	/**Set the MAC Address of this appliance
	 * @param string
	 */
	void setMacAddress(String stringg);

	/**
	 * Get the MAC Adress of this appliance
	 * @return
	 */
	String getMacAddress();

	/**
	 * Get the IP Address of this Appliance
	 * @return
	 */
	Object getIpAddress();
	
	/**
	 * Return the current state of the Appliance
	 * @return
	 */
	ApplianceState getState();
	
	
	

}
}