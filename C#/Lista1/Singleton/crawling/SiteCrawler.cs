using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton.crawling
{
    public interface ISiteCrawler
    {
        ISiteCrawler withURL(String url);

        ISiteCrawler crawl();

        Dictionary<String, StringBuilder> packSiteContens();
    }
}