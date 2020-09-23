using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMADA_NET_AUTOMATED.Tests;
using OpenQA.Selenium;
using OMADA_NET_AUTOMATED.Pages;
using OpenQA.Selenium.Support.UI;

namespace OMADA_NET_AUTOMATED
{
    [TestClass]
    public class FormTests : TestBase
    {
        [TestMethod]
        [DataRow("chrome")]
        [DataRow("firefox")]
        public void FormTest(string browser)
        {

            Setup(browser);
            foreach (string url in Form.uriList)
            {
                driver.Url = url;

                driver.FindElement(By.XPath(Form.submitButton)).Click();
                var errorList = driver.FindElements(By.XPath(Form.errorElement));

                if (errorList.Count==8)
                {
                    CheckFor7Field(errorList.Count);
                }
                else if (errorList.Count == 9)
                {
                    CheckFor8Field(errorList.Count);
                }
                else if (errorList.Count == 12)
                {
                    CheckFor10Field(errorList.Count);
                }
            }
            TearDown();

        }

        private void CheckFor7Field(int countOfErrors)
        {
            for (int i = 0; i < countOfErrors; i++)
            {

                Assert.IsTrue(countOfErrors - i != driver.FindElements(By.XPath(Form.errorElement)).Count-2, "validation error");

                if (i == 0)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[0].SendKeys("TestFirstName");
                }
                else if (i == 1)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[1].SendKeys("TestLastName");
                }
                else if (i == 2)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[2].SendKeys("TestCompany");
                }
                else if (i == 3)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[3].SendKeys("Testemil@wp.com");
                }
                else if (i == 4)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[4].SendKeys("+123456789");
                }
                else if (i == 5)
                {
                    var select = new SelectElement(driver.FindElement(By.XPath(Form.textXPath)));
                    select.SelectByText("Togo");
                }
                else if (i == 6)
                {
                    var select = new SelectElement(driver.FindElements(By.XPath(Form.textXPath))[1]);
                    select.SelectByText("0-500");
                }
                else if (i == 7)
                {
                    driver.FindElement(By.XPath(Form.yesXPath)).Click();
                }

                driver.FindElement(By.XPath(Form.submitButton)).Click();

            }
        }

            private void CheckFor8Field(int countOfErrors)
            {
            for (int i = 0; i < countOfErrors; i++)
            {

                Assert.IsTrue(countOfErrors - i != driver.FindElements(By.XPath(Form.errorElement)).Count - 2, "validation error");

                if (i == 0)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[0].SendKeys("TestFirstName");
                }
                else if (i == 1)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[1].SendKeys("TestLastName");
                }
                else if (i == 2)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[2].SendKeys("TestCompany");
                }
                else if (i == 3)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[3].SendKeys("TestJob");
                }
                else if (i == 4)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[4].SendKeys("Testemil@wp.com");
                }
                else if (i == 5)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[5].SendKeys("+123456789");
                }
                else if (i == 6)
                {
                    var select = new SelectElement(driver.FindElement(By.XPath(Form.textXPath)));
                    select.SelectByText("Togo");
                }
                else if (i == 7)
                {
                    var select = new SelectElement(driver.FindElements(By.XPath(Form.textXPath))[1]);
                    select.SelectByText("0-500");
                }
                else if (i == 8)
                {
                    driver.FindElement(By.XPath(Form.yesXPath)).Click();
                }

                driver.FindElement(By.XPath(Form.submitButton)).Click();

            }

            }
        private void CheckFor10Field(int countOfErrors)
        {
            for (int i = 0; i < countOfErrors; i++)
            {

                Assert.IsTrue(countOfErrors-i != driver.FindElements(By.XPath(Form.errorElement)).Count-1, "validation error");

                if (i==0)
                {
                    var select = new SelectElement(driver.FindElement(By.XPath(Form.textXPath)));
                    select.SelectByText("HR");
                }
                else if (i == 1)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[0].SendKeys("TestFirstName");
                }
                else if (i == 2)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[1].SendKeys("TestLastName");
                }
                else if (i == 3)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[2].SendKeys("TestCompany");
                }
                else if (i == 4)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[3].SendKeys("TestJob");
                }
                else if (i==5)
                {
                    var select = new SelectElement(driver.FindElements(By.XPath(Form.textXPath))[1]);
                    select.SelectByText("VP");
                }
                else if (i == 6)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[4].SendKeys("Testemil@wp.com");
                }
                else if (i == 7)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[5].SendKeys("+123456789");
                }
                else if (i == 8)
                {
                    var select = new SelectElement(driver.FindElements(By.XPath(Form.textXPath))[2]);
                    select.SelectByText("Togo");
                }
                else if (i == 9)
                {
                    driver.FindElements(By.XPath(Form.textXPath))[6].SendKeys("TestSubject");
                }
                else if (i == 10)
                {
                    driver.FindElement(By.XPath(Form.yesXPath)).Click();
                }

                driver.FindElement(By.XPath(Form.submitButton)).Click();

            }

        }
    }
}
