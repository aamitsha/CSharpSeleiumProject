using OpenQA.Selenium;
using Selenium.Test.Buisness.Fuctions.Utilities;
using Selenium.Test.Common.Function.PageFuctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Buisness.Fuctions.BuisnessFunctions
{
    public class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver)
        {
        }
        By ProductNameAndSize(string product, string size) => By.XPath("//a[text()='" + product + "']//parent::p//following-sibling::small//a[contains(text(),'Size : " + size + "')]");
        By ProductPrice(string product, string price) => By.XPath("//a[text()='" + product + "']//ancestor::td//following-sibling::td[@class='cart_total']//span[normalize-space(text()='" + price + "')]");
        private By ProceedToCheckOutButton => By.XPath("//a[@title='Proceed to checkout']");
        private By AddressBlock => By.XPath("//span[text()=' Address']");
        private By ShippingBlock => By.XPath("//span[text()=' Shipping']");
        private By TermsCheckBox => By.XPath("//input[@id='cgv']");
        private By PayByBankWireLink => By.XPath("//a[@title='Pay by bank wire']");
        private By ConfirmOrderButtoon => By.XPath("//span[text()='I confirm my order']");
        private By ConfirmationMessage => By.XPath("//strong[text()='Your order on My Store is complete.']");
        private By LogOutButton => By.XPath("//a[@title='Log me out']");
        private By TotalCartPrice(string price) => By.XPath("//span[@id='total_price'][contains(text(),'" + price + "')]");
        private By ProceedToCheckOutSummary => By.XPath("//p[@class='cart_navigation clearfix']//a[@title='Proceed to checkout']");
        private By ProceedToCheckOutShipping => By.XPath("//button[@type='submit'][@name='processCarrier']");
        private By ProceedToCheckOutAddress => By.XPath("//button[@type='submit'][@name='processAddress']");
        private By TermsLabel => By.XPath("//label[text()='I agree to the terms of service and will adhere to them unconditionally.']");
        public OrderPage VerifyProductAndSize(string product, string size)
        {
            Assertions.AssetIsTrue(IsElementDisplayed(ProductNameAndSize(product, size)), "Product Size Mismatch");
            return this;
        }
        public OrderPage VerifyProductPrice(string product, string price)
        {
            Assertions.AssetIsTrue(IsElementDisplayed(ProductPrice(product, price)), "Product price mismatch ");
            return this;
        }
        public OrderPage ClickProceedToCheckOutButtonOnAddressPage()
        {
            Click(ProceedToCheckOutAddress, "ProceedToCheckOutButton");
            return this;
        }

        public OrderPage VerifyAddressBlock()
        {
            Assertions.AssetIsTrue(IsElementDisplayed(AddressBlock), "Address  Block");
            return this;
        }
        public OrderPage VerifyShippingBlock()
        {
            Assertions.AssetIsTrue(IsElementDisplayed(ShippingBlock), "Address  Block");
            return this;
        }
        public OrderPage SelectTermsCheckBox()
        {
            WaitForElementToBeClickable(TermsCheckBox, 50);
            Click(TermsCheckBox, "TermsCheckBox");
            return this;
        }
        public OrderPage ClickTermsTitle()
        {

            Click(TermsLabel, "TermsLabel");
            return this;
        }
        public OrderPage ClickPayByWireLink()
        {
            Click(PayByBankWireLink, "PayByBankWireLink");
            return this;
        }
        public OrderPage ClickConfirmOrderButton()
        {
            Click(ConfirmOrderButtoon, "ConfirmOrderButtoon");
            return this;
        }
        public OrderPage VerifyOrderConfirmation()
        {
            Assertions.AssetIsTrue(IsElementDisplayed(ConfirmationMessage), "ConfirmationMessage");
            return this;
        }
        public OrderPage ClickLogOutButton()
        {
            Click(LogOutButton, "LogOutButton");
            return this;
        }
        public string getShippingPrice()
        {
            string shippingPrice = driver.FindElement(By.XPath("//td[@id='total_shipping']")).Text;
            return shippingPrice;
        }
        public OrderPage verifyTotalPrice(string prodcutOne, string ProductTwo, string shippingPrice)
        {
            decimal prodOne = Utility.RemoveSpecialCharsAndConverIntoDecimal(prodcutOne);
            decimal prodTwo = Utility.RemoveSpecialCharsAndConverIntoDecimal(ProductTwo);
            decimal prodThree = Utility.RemoveSpecialCharsAndConverIntoDecimal(shippingPrice);
            decimal totalPrice = prodOne + prodTwo + prodThree;
            string Total = totalPrice.ToString();
            Assertions.AssetIsTrue(IsElementDisplayed(TotalCartPrice(Total)), "total price mismatch");
            return this;
        }
        public OrderPage ClickProceedToCheckOutOnSummaryPage()
        {
            Click(ProceedToCheckOutSummary, "ProceedToCheckOutSummary");
            return this;
        }
        public OrderPage ClickProceedToCheckOutOnShippingPage()
        {
            Click(ProceedToCheckOutShipping, "ClickProceedToCheckOutOnShippingPage");
            return this;
        }


    }
}
