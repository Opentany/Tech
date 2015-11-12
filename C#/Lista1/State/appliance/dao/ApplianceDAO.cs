using System;

namespace State.appliance.dao
{
    public interface ApplianceDAO
    {

        Appliance findByMacAddress(String macAddress);
    }
}