using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Common.Function.Reporting
{
    public class LoggerClass
    {
        private int stepCount = 1;
        private string filePath;
        private TestContext context;
        private StreamWriter outputFile;

        public LoggerClass(TestContext context, string filePath)
        {
            this.context = context;
            outputFile = new StreamWriter(this.filePath = filePath, true);
            context.AddResultFile(filePath);
        }

        public void LogMessage(string logMessage)
        {
            outputFile.WriteLine("{0}{1}{2}{3}", stepCount.ToString("000"), ".", " ", logMessage);
            outputFile.Flush();
            stepCount++;
        }
        public void LogException(Exception ex, string logMessage)
        {
            LogMessage("\n Error:" + logMessage);
            LogMessage("\n Exception: " + ex.Message);
            LogMessage("\n StackTrace:" + ex.StackTrace);
        }
        public void LogError(Exception ex, string customMsg)
        {
            LogMessage("\nError: " + customMsg);
            LogMessage("\nException: " + ex.Message);
            LogMessage("\nStackTrace: " + ex.StackTrace);
        }

        public void TakeScreenShot(IWebDriver driver, string fileName)
        {
            if (driver != null)
            {
                Screenshot sShot = ((ITakesScreenshot)driver).GetScreenshot();
                sShot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                context.AddResultFile(fileName);
            }
            else
            {
                LogMessage("\n Oops!.. looks like browser was closed befire taking a screenshot");
            }
        }
    }
}
