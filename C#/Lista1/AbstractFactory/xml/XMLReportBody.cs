using System;

namespace AbstractFactory.xml
{
    public class XMLReportBody : ReportBody  {

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.creational.asbtractfactory.ReportElement#getType()
	 */
	public String getType() {
		
		return "XML";
	}


}
}