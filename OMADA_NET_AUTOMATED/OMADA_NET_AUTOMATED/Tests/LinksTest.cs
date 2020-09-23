using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMADA_NET_AUTOMATED.Resources;
using OpenQA.Selenium;

namespace OMADA_NET_AUTOMATED.Tests
{

    [TestClass]
    public class LinksTest : TestBase
    {
        static List<string> urlList = new List<string>()
        {
            "https://www.omada.net/en-us/omada-homepage",
            "https://www.omada.net/en-us/solutions/solution-overview",
            "https://www.omada.net/en-us/business-value",
            "https://www.omada.net/en-us/services/services",
            "https://www.omada.net/en-us/industries",
            "https://www.omada.net/en-us/more",
            "https://www.omada.net/en-us/more/resources",

        };



        [TestMethod]
        [DataRow("chrome")]
        [DataRow("firefox")]
        public void LinkTest(string browser)
        {
            
            Setup(browser);
            foreach (string url in urlList)
            {
                driver.Url = url;

                var Links = driver.FindElements(By.TagName(Index.linkTagName));

                for (int i = 0; i < Links.Count; i++)
                {
                    if (driver.FindElements(By.TagName(Index.linkTagName))[i].Text.Equals(""))
                    {
                        continue;
                    }
                    try
                    {
                        driver.FindElement(By.XPath(Index.closeXPath)).Click();
                    }
                    catch{ }
                    try
                    {
                        driver.FindElements(By.TagName(Index.linkTagName))[i].Click();
                        Thread.Sleep(500);
                    }
                    catch{}
                    driver.Navigate().GoToUrl(url);

                }
            }

        }
    }
}
