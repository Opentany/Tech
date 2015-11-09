namespace FactoryMethod
{
    public class JSONReport : AbstractReport {


	public override void generateReport(ReportData data) {
		setReportContent("JSON Report. Name: " + data.getName());

	}

}
}