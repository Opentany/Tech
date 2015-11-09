namespace FactoryMethod
{
    public class PDFReportGenerator : ReportGenerator
    {
        protected override Report intantiateReport()
        {
            return new PDFReport();
        }
    }
}