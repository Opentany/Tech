using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class AbstractReport : Report
    {
        private String reportContent;

        public virtual void generateReport(ReportData data)
        {
            
        }

        public String getReportContent()
        {
            return reportContent;
        }

        protected void setReportContent(String content)
        {
            this.reportContent = content;
        }
    }
}
