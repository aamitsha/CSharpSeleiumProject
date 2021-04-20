 using Selenium.Test.Buisness.Fuctions.BuisnessFunctions;
 using Selenium.Test.Buisness.Fuctions.Utilities;
 using Selenium.Test.Common.Function.Reporting;
 using Microsoft.VisualStudio.TestTools.UnitTesting;
 using OpenQA.Selenium;
 using System;
 using System.IO;
 using static Selenium.Test.Buisness.Fuctions.Utilities.Utility;
using static Selenium.Test.Buisness.Fuctions.BasePage;

namespace Selenium.Test.Buisness.Fuctions.TestCases
    {       
        public abstract class TestBase
        {
            protected DateTime mTestStartTime;
            protected IWebDriver mDriver;
            protected LoggerClass mLogger;
            protected string mLogFileName;
            protected string mLogFilePath;
            protected LoginPage login;

            public TestContext TestContext
            {
                get
                {
                    return mTestContext;
                }
                set
                {
                    mTestContext = value;
                }
            }
            protected TestContext mTestContext;


            protected void BaseTestInitialize(EnvironmentURL URLName)
            {
                if (mLogger == null)
                {
                    var testStartTime = Utility.GenerateTimeStamp();
                    mLogFileName = string.Concat(TestContext.TestName, "_", testStartTime.Replace(" ", "_"));
                    mLogger = SetLogger(TestContext, Path.Combine(TestContext.DeploymentDirectory, mLogFileName + ".txt"));
                }
                mDriver = LoadBrowserConfig(mDriver);
                mDriver.Url = @"https://www.google.com/";
                login = new LoginPage(mDriver);
                mTestStartTime = DateTime.Now;
                mLogger.LogMessage("Selenium WebDriver Test Log | " + TestContext.TestName);
                login.NavigateTo(URLName);


            }
            protected void APIBaseTestInitialize()
            {
                if (mLogger == null)
                {
                    var testStartTime = Utility.GenerateTimeStamp();
                    mLogFileName = string.Concat(TestContext.TestName, "--", testStartTime.Replace(" ", "_"));
                    mLogFilePath = Path.Combine(TestContext.DeploymentDirectory, mLogFileName + ".txt");
                    mLogger = SetLogger(TestContext, mLogFilePath);
                }

                login = new LoginPage(mDriver);
                mTestStartTime = DateTime.Now;
                mLogger.LogMessage("API Test Log| " + TestContext.TestName);

            }

            protected void BaseTestCleanup()
            {
                var executionTime = DateTime.Now - mTestStartTime;
                mLogger.LogMessage("Test " + TestContext.CurrentTestOutcome + "Total time" + executionTime);
                if (TestContext.CurrentTestOutcome.ToString() == "Failed")
                {
                    mLogger.TakeScreenShot(mDriver, mLogFileName + ".jpg");
                }
                mDriver.Quit();
            }
            protected void APIBaseTestCleanup()
            {
                var executionTime = DateTime.Now - mTestStartTime;
                mLogger.LogMessage("Test " + TestContext.CurrentTestOutcome + "Total time" + executionTime);

            }

        }
}


