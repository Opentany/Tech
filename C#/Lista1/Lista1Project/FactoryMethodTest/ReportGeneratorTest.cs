using System;
using FactoryMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty.FactoryMethodTest
{
    [TestClass]
    public class ReportGeneratorTest : AbstractReportingTest{

	
	
	[TestMethod]
	public void testCreateJSONReport() {
		ReportData reportData = createDummyReportData();
        JSONReportGenerator generator = new JSONReportGenerator();
		Report generatedReport = generator.generateReport(reportData, "JSON");
		Assert.AreEqual("JSON Report. Name: "+reportData.getName(), generatedReport.getReportContent());
	}
	
	
	[TestMethod]
	public void testCreateXMLReport() {
		ReportData reportData = createDummyReportData();
        XMLReportGenerator generator = new XMLReportGenerator();
		Report generatedReport = generator.generateReport(reportData, "XML");
		Assert.AreEqual("XML Report. Name: "+reportData.getName(), generatedReport.getReportContent());
	}
	
	[TestMethod]
	public void testCreateHTMLReport() {
		ReportData reportData = createDummyReportData();
        HTMLReportGenerator generator = new HTMLReportGenerator();
		Report generatedReport = generator.generateReport(reportData, "HTML");
		Assert.AreEqual("HTML Report. Name: "+reportData.getName(), generatedReport.getReportContent());
	}

    [TestMethod]
	public void testCreatePDFReport() {
		ReportData reportData = createDummyReportData();
		PDFReportGenerator generator = new PDFReportGenerator();
		Report generatedReport = generator.generateReport(reportData, "PDF");
		Assert.AreEqual("PDF Report. Name: "+reportData.getName(), generatedReport.getReportContent());
	}
	

	
	
}
}
