using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singleton.crawling
{
    public class DummySiteCrawler : ISiteCrawler
    {
        private Dictionary<String, StringBuilder> urlContents;

        public DummySiteCrawler()
        {
            this.urlContents = createNewSiteContens();
        }

        public ISiteCrawler withURL(String url)
        {
            this.urlContents.put(url, new StringBuilder());
            return this;
        }


        private void crawl(String urlString, StringBuilder targetBuffer)
        {
            try
            {
                Uri url = new Uri(urlString);
                BufferedStream reader = new BufferedReader(new InputStreamReader(
                    url.openStream()));
                String line;
                while ((line = reader.readLine()) != null)
                {
                    targetBuffer.append(line);
                }
                reader.EndRead(null);
            }
            catch (Exception e)
            {
                throw new CannotCrawlException(e);
            }
        }

        public ISiteCrawler crawl()
        {
            foreach (var url in this.urlContents.Keys)
            {
                crawl(url, this.urlContents.);
            }

            return this;
        }

        /* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.creational.singleton.SiteCrawler#getSiteContents()
	 */

        public Dictionary<String, StringBuilder> packSiteContens()
        {
            //return the reference and reuit for other instance
            Dictionary<String, StringBuilder> retunrContents = this.urlContents;
            this.urlContents = createNewSiteContens();
            return retunrContents;
        }

        /**
	 * can override
	 * @return
	 */

        protected Dictionary<String, StringBuilder> createNewSiteContens()
        {
            return new Dictionary<string, StringBuilder>();
        }
    }
}
    