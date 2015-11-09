using System;
using AbstractFactory;
using AbstractFactory.json;
using AbstractFactory.xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty
{
    [TestClass]
    public class ReportTest
    {
    [TestMethod]
	public void testCreateJSONReport() {

		Report report = new Report(new JSONReportElementsFactory());
		Assert.AreEqual("JSON", report.getBody().getType());
		Assert.AreEqual("JSON", report.getHeader().getType());
		Assert.AreEqual("JSON", report.getFooter().getType());

	}

	[TestMethod]
	public void testCreateXMLReport() {

		Report report = new Report(new XMLReportElementsFactory());
		Assert.AreEqual("XML", report.getBody().getType());
		Assert.AreEqual("XML", report.getHeader().getType());
		Assert.AreEqual("XML", report.getFooter().getType());

	}
    }
}
