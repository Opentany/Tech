﻿using System;

namespace AbstractFactory.json
{
    public class JSONReportBody : ReportBody {

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.creational.asbtractfactory.ReportElement#getType()
	 */
	public String getType() {
		return "JSON";
	}

}
}