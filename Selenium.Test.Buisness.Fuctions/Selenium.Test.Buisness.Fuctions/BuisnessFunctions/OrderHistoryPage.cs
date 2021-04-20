using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Selenium.Test.Common.Function.PageFuctions;
using System.Threading;



namespace Selenium.Test.Buisness.Fuctions.BuisnessFunctions
{
    public class OrderHistoryPage : BasePage
    {
        public OrderHistoryPage(IWebDriver driver) : base(driver)
        {

        }


        private By OrderLink(string date) => By.XPath("(//td[normalize-space(text()='" + date + "')]//parent::td//a[@class='color-myaccount'])[1]");
        private By AddMessageTextBox => By.XPath("//textarea[@class='form-control']");
        private By SubmitMessageButton => By.XPath("//button[@type='submit'][@name='submitMessage']");
        private By MessageCell(string message) => By.XPath("//div[@id='block-order-detail']//tr[@class='first_item item']//td[text()='" + message + "']");
        private By PaymentMethodCell(string methodName) => By.XPath("(//td[@class='history_method'])[(text()='" + methodName + "')][1]");
        public OrderHistoryPage ClickOrderLink(string date)
        {
            WaitForElementToBeVisible(OrderLink(date), 40);
            Click(OrderLink(date), "Order Link");
            Actions action = new Actions(driver);
            action.Click(driver.FindElement(OrderLink(date))).Build().Perform();
            return this;
        }
        public OrderHistoryPage ChooseOrderFromDropDown()
        {
            Thread.Sleep(10000);
            IWebElement orderElement = driver.FindElement(By.XPath("//select[@name='id_product']"));
            SelectElement element = new SelectElement(orderElement);
            element.SelectByValue("1");
            return this;
        }
        public OrderHistoryPage EnterMessage(string message)
        {
            EnterText(AddMessageTextBox, message, "AddMessageTextBox");
            return this;
        }
        public OrderHistoryPage ClickSendButton()
        {
            Click(SubmitMessageButton, "SubmitMessageButton");
            return this;
        }
        public OrderHistoryPage VerifyMessageIsSaved(string message)
        {
            Thread.Sleep(10000);
            Assertions.AssetIsTrue(IsElementDisplayed(MessageCell(message)), "Message not displayed");
            return this;
        }
        public OrderHistoryPage VerifyPaymentMethod(string paymentMethod)
        {
            Assertions.AssetIsTrue(IsElementDisplayed(PaymentMethodCell(paymentMethod)), "Payment method ");
            return this;
        }

    }
}
