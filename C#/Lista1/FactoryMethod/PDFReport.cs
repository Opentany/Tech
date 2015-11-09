namespace FactoryMethod
{
    public class PDFReport : AbstractReport {

	public override void generateReport(ReportData data) {
		setReportContent("PDF Report. Name: " + data.getName());

	}

}
}