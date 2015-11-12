using System;

namespace Flyweight.controller
{
    public class HumiditySensor : Sensor
    {
        /* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.creational.flyweight.controller.Sensor#read()
	 */

        public String read(String ipAddress)
        {
            return "87";
        }
    }
}