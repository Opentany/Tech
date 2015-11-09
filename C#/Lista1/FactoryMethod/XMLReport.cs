namespace FactoryMethod
{
    public class XMLReport : AbstractReport{

	public override void generateReport(ReportData data) {
		setReportContent("XML Report. Name: "+data.getName());
		
	}

}
}