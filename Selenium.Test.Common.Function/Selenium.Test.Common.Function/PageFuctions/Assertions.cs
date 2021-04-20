using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Selenium.Test.Common.Function.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Common.Function.PageFuctions
{
    public class Assertions
    {
        private static LoggerClass log = WebDriverBase.log;

        public static void AssetIsTrue(bool actual, string errorMessage)
        {
            try
            {
                Assert.IsTrue(actual, errorMessage);
            }
            catch (AssertFailedException ex)
            {
                log.LogError(ex, errorMessage);
                throw;
            }
        }
        public static void AssetContains(string actual, string expected, string errorMessage)
        {
            try
            {
                if (!actual.Contains(expected))
                {
                    throw new AssertFailedException(string.Format("string does not contains the expected value . Expected: {0}  Actual :{1}", expected, actual));
                }
            }
            catch (AssertFailedException af)
            {
                log.LogMessage("asser failed" + af.StackTrace);
                throw;
            }
        }
        public static void AssertAreEqual(string expected, string actual, string errorMessage)
        {
            try
            {
                Assert.AreEqual(expected, actual, errorMessage);
                log.LogMessage("Passed");
            }
            catch (AssertFailedException ex)
            {
                log.LogError(ex, errorMessage);
                throw;
            }
        }

    }
}
