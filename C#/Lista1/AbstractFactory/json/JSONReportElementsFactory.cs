namespace AbstractFactory.json
{
    public class JSONReportElementsFactory : AbstractReportElementsFactory
    {
        public override ReportBody createReportBody()
        {
            return new JSONReportBody();
        }

        public override ReportFooter createReportFooter()
        {
            return new JSONReportFooter();
        }

        public override ReportHeader createReportHeader()
        {
            return new JSONReportHeader();
        }
    }
}