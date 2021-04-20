using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Test.Common.Function.PageFuctions;
using Selenium.Test.Common.Function.Reporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Xml;
using static Selenium.Test.Buisness.Fuctions.Utilities.Utility;

namespace Selenium.Test.Buisness.Fuctions
{
    public class BasePage : WebDriverBase
    {
        public static string ChromeDriverPath = AppSettings.Get("ChromeDriverPath");


        public BasePage(IWebDriver driver) : base(driver)
        {

        }
        public static IWebDriver LoadBrowserConfig(IWebDriver driver)
        {
            if (AppSettings["Browser"] == "Chrome")
            {
                driver = new ChromeDriver(ChromeDriverPath);
            }
            else
            {
                log.LogMessage("Browser value is not provided.");
            }
            return driver;
        }

        public void NavigateTo(EnvironmentURL url)
        {

            string URL = ReadEnvironmentUrl(url).ToString();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);

        }
        public static string ReadEnvironmentUrl(EnvironmentURL urlName)
        {
            string properUrl = string.Empty;
            string fileName = string.Concat(AppSettings["TestEnvironment"], ".config");
            string filePath = Path.Combine(AppSettings["ConfigFolder"], fileName);
            string fullPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), filePath));
            Dictionary<string, string> settings = new Dictionary<string, string>();

            using (var xmlReader = XmlReader.Create(fullPath))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Setting")
                    {
                        settings.Add(xmlReader.GetAttribute("Name"), xmlReader.ReadElementContentAsString());
                    }
                }
            }

            if (settings.ContainsKey(urlName.ToString()))
            {
                properUrl = settings[urlName.ToString()];
            }

            return properUrl;
        }
        public static LoggerClass SetLogger(TestContext testContext, string logFilePath)
        {
            return log = new LoggerClass(testContext, logFilePath);
        }



    }
}
