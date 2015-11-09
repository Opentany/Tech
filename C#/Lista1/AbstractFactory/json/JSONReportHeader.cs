using System;

namespace AbstractFactory.json
{
    public class JSONReportHeader : ReportHeader {

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * eu.jpereira.trainings.designpatterns.creational.asbtractfactory.ReportElement
	 * #getType()
	 */

	public String getType() {

		return "JSON";
	}

}
}