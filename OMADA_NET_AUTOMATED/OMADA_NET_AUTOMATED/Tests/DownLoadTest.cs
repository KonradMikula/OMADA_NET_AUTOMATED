using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMADA_NET_AUTOMATED.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OMADA_NET_AUTOMATED.Pages;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using System.Net.Cache;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.ComponentModel;

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


            //Omada_Identity_Cloud_Guide_2020
            driver.FindElement(By.XPath($"//*[text()='Download Guide']")).Click();
            DownloadFilePath = WaitForDownloadFile(Download.OIGC2020Name);

            if (!CalculateMD5(DownloadFilePath).Equals(Download.OIGC2020MD5))
            {
                Assert.Fail("File error" + DownloadFilePath);
            }




            
            TearDown();

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
