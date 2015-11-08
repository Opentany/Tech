using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Singleton.crawling;


namespace Singleton
{
    public class ReportBuilder
    {
        // Instance variables
        private Dictionary<String, StringBuilder> sitesContens;

        private ISiteCrawler siteCrawler;

        // Class variables
        // Single instance
        private static ReportBuilder instance;
        private static List<String> configuredSites;

        // Class initializer block
        private static 
        {
            configuredSites = new List<String>();
            configuredSites.Add("http://www.wikipedia.com");
            configuredSites.Add("http://jpereira.eu");
            configuredSites.Add("http://stackoverflow.com");
        }

        public ReportBuilder()
        {
            initiatlize();
        }

        /**
	 * Very time consuming initialize method...
	 */

        private void initiatlize()
        {
            //defer it to an factory method
            this.siteCrawler = createSiteCrawler();

            // Now crawl some pre-defined sites
            foreach (var url in configuredSites)
            {
                this.siteCrawler.withURL(url);
            }
            try
            {
                this.setSitesContens(this.siteCrawler.crawl().packSiteContens());
            }
            catch (CannotCrawlException e)
            {
                // this singleton instance is in very bad shape... what wiil you do?
                // I cannot recover from this and this instance will be useless to
                // clients...
                throw new SystemException("Could not load sites:" + e.Message);
            }
        }

        /**
	 * Factory method with default implementation
	 * 
	 * @return
	 */

        protected ISiteCrawler createSiteCrawler()
        {
            return new DummySiteCrawler();
        }

        /**
	 * Get a single instance of type ReportBuilder
	 * 
	 * @return A single instance
	 */

        public static ReportBuilder getInstance()
        {
            Console.WriteLine("Getting instance for Thread " + Thread.currentThread().getId());
            if (instance == null)
            {
                Console.WriteLine("Instance is null for Thread " + Thread.currentThread().getId());
                instance = new ReportBuilder();
                Console.WriteLine("Returing " + instance.hashCode() + " instance to Thread " +
                                  Thread.currentThread().getId());
            }
            return instance;
        }

        /**
	 * 
	 * @return the sitesContens
	 * 
	 */

        public Dictionary<String, StringBuilder> getSitesContens()
        {
            return sitesContens;
        }

        /**
	 * @param sitesContens
	 *            the sitesContens to set
	 */

        private void setSitesContens(Dictionary<String, StringBuilder> sitesContens)
        {
            this.sitesContens = sitesContens;
        }

        /**
	 * 
	 */

        public static void ResetInstance()
        {
            instance = null;
        }
    }
}
