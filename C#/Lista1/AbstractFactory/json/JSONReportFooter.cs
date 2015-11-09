using System;

namespace AbstractFactory.json
{
    public class JSONReportFooter : ReportFooter {

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