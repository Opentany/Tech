namespace FactoryMethod
{
    public class XMLReportGenerator : ReportGenerator
    {
        protected override Report intantiateReport()
        {
            return new XMLReport();
        }
    }
}