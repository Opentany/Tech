namespace AbstractFactory
{
    public abstract class AbstractReportElementsFactory
    {

        public virtual ReportBody createReportBody()
        {
            return null;
        }

        public virtual ReportFooter createReportFooter()
        {
            return null;
        }


        public virtual ReportHeader createReportHeader()
        {
            return null;
        }
    }
}

