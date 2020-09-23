using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMADA_NET_AUTOMATED.Tests;
using OpenQA.Selenium;
using OMADA_NET_AUTOMATED.Resources;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace OMADA_NET_AUTOMATED
{
    [TestClass]
    public class DownLoadTest : TestBase
    {

        string downloadLocation = "C:\\Users\\" + Environment.UserName + "\\Downloads";



        [TestMethod]
        [DataRow("chrome")]
        [DataRow("firefox")]
        public void download(string browser)
        {

            Setup(browser);

           driver.Url = "https://www.omada.net/en-us/more/resources/omada-identity-suite-solution-overview";
           string DownloadFilePath = "";


            driver.FindElement(By.XPath(Download.DownLoadGuide)).Click();
            DownloadFilePath = WaitForDownloadFile(Download.OIGC2020Name);

            if (!CalculateMD5(DownloadFilePath).Equals(Download.OIGC2020MD5))
            {
                Assert.Fail("File error" + DownloadFilePath);
            }

            checkFile(Download.Case1Name, Download.Case1Link, Download.Case1MD);
            checkFile(Download.Case2Name, Download.Case2Link, Download.Case2MD);
            checkFile(Download.Case3Name, Download.Case3Link, Download.Case3MD);
            checkFile(Download.Case4Name, Download.Case4Link, Download.Case4MD);
            checkFile(Download.Case5Name, Download.Case5Link, Download.Case5MD);
            checkFile(Download.Case6Name, Download.Case6Link, Download.Case6MD);
            checkFile(Download.Case7Name, Download.Case7Link, Download.Case7MD);
            checkFile(Download.Case8Name, Download.Case8Link, Download.Case8MD);
            checkFile(Download.Case9Name, Download.Case9Link, Download.Case9MD);




            TearDown();

        }

        private void checkFile(string name, string link, string md5)
        {
            string DownloadFilePath = "";
            driver.Url = link;
            try
            {
                driver.FindElement(By.XPath(Download.Close)).Click();
            }
            catch { }
            driver.FindElement(By.XPath(Download.DownloadCustomerCase)).Click();
            DownloadFilePath = WaitForDownloadFile(name);

            if (!CalculateMD5(DownloadFilePath).Equals(md5))
            {
                Assert.Fail("File error" + DownloadFilePath);
            }

        }

        private string CalculateMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private string WaitForDownloadFile(string nameFile)
        {
            
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(2000);
                var lastModifiedFileTime = System.IO.File.GetLastWriteTime(CheckLatestFileInFolder(nameFile));

                if (DateTime.Now.Subtract(lastModifiedFileTime).TotalSeconds<10)
                {
                    break;
                }
                if (i==5)
                {
                    Assert.Fail("Download Error");
                }
            }
            return downloadLocation + "\\" +CheckLatestFileInFolder(nameFile);
        }

        private string CheckLatestFileInFolder(string nameFile)
        {
            var files = new DirectoryInfo(downloadLocation).GetFiles("*" + nameFile + "*");
            string latestfile = "";
            DateTime lastModified = DateTime.MinValue;

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastModified)
                {
                    lastModified = file.LastWriteTime;
                    latestfile = file.Name;
                }
            }
            return latestfile;
        }


    }
}
