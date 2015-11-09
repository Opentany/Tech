namespace FactoryMethod
{
    public class HTMLReport : AbstractReport
    {
        public override void generateReport(ReportData data)
        {
            setReportContent("HTML Report. Name: " + data.getName());
        }
    }
}