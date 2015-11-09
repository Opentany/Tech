namespace AbstractFactory.xml
{
    public class XMLReportElementsFactory : AbstractReportElementsFactory
    {
        public override ReportFooter createReportFooter()
        {
            return new XMLReportFooter();
        }

        public override ReportHeader createReportHeader()
        {
            return new XMLReportHeader();
        }

        public override ReportBody createReportBody()
        {
            return new XMLReportBody();
        }
    }
}