namespace FactoryMethod
{
    public class JSONReportGenerator : ReportGenerator
    {
        protected override Report intantiateReport()
        {
            return new JSONReport();
        }
    }
}