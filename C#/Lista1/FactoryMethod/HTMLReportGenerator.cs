namespace FactoryMethod
{
    public class HTMLReportGenerator : ReportGenerator
    {
        protected override Report intantiateReport()
        {
            return new HTMLReport();
        }
    }
}