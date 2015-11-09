using System;

namespace AbstractFactory.xml
{
    public class XMLReportHeader : ReportHeader {

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.creational.asbtractfactory.ReportElement
	 * #getType()
	 */
	public String getType() {
		return "XML";
	}

}
}