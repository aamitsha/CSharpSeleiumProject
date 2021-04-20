using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Test.Common.Function.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Common.Function.PageFuctions
{
    public partial class WebDriverBase
    {
        protected internal IWebDriver driver;
        public static LoggerClass log;

        public WebDriverBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool WaitForElementToBeVisible(By elementLocator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementLocator));
                return true;
            }
            catch
            {
                log.LogMessage("Element Not Found");
                return false;
            }
        }

        public bool WaitForElementToBeClickable(By elementLocator, int timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
                return true;
            }

            catch (StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public bool Click(By elementLocator, int timeoutInSeconds)
        {
            WaitForElementToBeVisible(elementLocator, timeoutInSeconds);
            try
            {
                driver.FindElement(elementLocator).Click();
                return true;
            }

            catch (StaleElementReferenceException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
                throw;
            }

        }
        public void EnterText(By element, string text, string logMsg, int timeoutSeconds = 20)
        {
            try
            {
                WaitForElementToBeVisible(element, timeoutSeconds);
                driver.FindElement(element).Clear();
                driver.FindElement(element).SendKeys(text);
                log.LogMessage(string.Format("Entered '{0}' in '{1}' textbox | {2}", text, logMsg, element));
            }
            catch (Exception ex)
            {
                log.LogException(ex, string.Format("Failed to enter '{0}' in '{1}' textbox | {2}", text, logMsg, element));
                throw;
            }
        }
        public void Click(By elementLocator, string logMsg, int timeoutSeconds = 20)
        {
            try
            {
                WaitForElementToBeClickable(elementLocator, timeoutSeconds);
                driver.FindElement(elementLocator).Click();
                log.LogMessage(string.Format("Clicked '{0}' | {1}", logMsg, elementLocator));
            }
            catch (Exception ex)
            {
                log.LogError(ex, string.Format("Failed to click '{0}' | {1} ", logMsg, elementLocator));
                throw;
            }
        }
        public bool IsElementDisplayed(By elementLocator)
        {
            bool isDisplayed;
            try
            {
                isDisplayed = driver.FindElement(elementLocator).Displayed;
            }
            catch
            {
                isDisplayed = false;
            }
            return isDisplayed;
        }
        public void ClickJS(By elementLocator, string logMsg, int timeoutSeconds = 20)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", elementLocator);
                log.LogMessage(string.Format("Clicked '{0}' | {1}", logMsg, elementLocator));
            }
            catch (Exception ex)
            {
                log.LogError(ex, string.Format("Failed to click '{0}' | {1} ", logMsg, elementLocator));
                throw;
            }
        }
    }
}
