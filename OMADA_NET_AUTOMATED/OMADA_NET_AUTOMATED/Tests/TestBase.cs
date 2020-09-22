using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace OMADA_NET_AUTOMATED.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        string downloadLocation = "C:\\Users\\" + Environment.UserName + "\\Downloads";

        public void Setup(String browser)
        {
            if (browser.Equals("chrome"))
                driver = new ChromeDriver();
            if (browser.Equals("firefox"))
            {
                var profileManager = new FirefoxProfileManager();
                var profile = profileManager.GetProfile("default");

                FirefoxOptions ffp = new FirefoxOptions();
                ffp.Profile = profile;

                driver = new FirefoxDriver(ffp);

            }  
            driver.Manage().Window.Maximize();

        }

        public void TearDown()
        {
            driver.Close();
        }

    }
}
