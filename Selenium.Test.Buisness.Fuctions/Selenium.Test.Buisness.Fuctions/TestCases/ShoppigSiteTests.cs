using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Selenium.Test.Buisness.Fuctions.BuisnessFunctions;
using Selenium.Test.Buisness.Fuctions.Utilities;
using Selenium.Test.Common.Function.Reporting;
using System;
using System.IO;
using static Selenium.Test.Buisness.Fuctions.Utilities.Utility;
using static Selenium.Test.Buisness.Fuctions.BasePage;

namespace Selenium.Test.Buisness.Fuctions.TestCases
{
    [TestClass]
    public class TestClasOne : TestBase
    {

        private string EmailID = "amit_automation@gmail.com";
        private string Password = "FujitsuTest";

        [TestInitialize]
        public void TestInitialize()
        {
            BaseTestInitialize(EnvironmentURL.AutomationPractice);
        }

        [TestMethod]
        [TestCategory("Automation Practice")]
        public void TestPurchaseTwoItems()
        {
            string productOnePrice;
            string productTwoPrice;
            string shippingPrice;
            string productOne = "Faded Short Sleeve T-shirts";
            string productOneLink = @"http://automationpractice.com/index.php?id_product=1&controller=product&search_query=Faded+Short+Sleeve+T-shirts&results=1";
            string productTwo = "Printed Summer Dress";
            string productTwoLink = @"http://automationpractice.com/index.php?id_product=5&controller=product&search_query=Printed+Summer+Dress&results=3";

            var loginPage = login.ClickSIgnInLInk()
                                .EnterEmailID(EmailID, "Email ID")
                                .EnterPassword(Password, "Password")
                                .ClickLoginButton();

            var ProductPage = loginPage.SearchProduct(productOne)
                                .ClickSearchProductButton()
                                .ClickOnProductLink(productOne, productOneLink)
                                .SelectSize(ProductSize.M);
            productOnePrice = ProductPage.GetProductPrice();

                              ProductPage.ClickAddToCartButton()
                                .ClickContinueShoppingButton()
                                .SearchProduct(productTwo)
                                .ClickSearchProductButton()
                                .ClickOnProductLink(productTwo, productTwoLink);
            productTwoPrice = ProductPage.GetProductPrice();
            var OrderPage = ProductPage.ClickAddToCartButton()
                                .ClickPreceedToCheckOutButton()
                                .VerifyProductAndSize(productOne, ProductSize.M.ToString())
                                .VerifyProductPrice(productOne, productOnePrice)
                                .VerifyProductAndSize(productTwo, ProductSize.S.ToString())
                                .VerifyProductPrice(productTwo, productTwoPrice);
            shippingPrice = OrderPage.getShippingPrice();

            OrderPage.verifyTotalPrice(productOnePrice, productTwoPrice, shippingPrice)
                               .ClickProceedToCheckOutOnSummaryPage()
                               .VerifyAddressBlock()
                               .ClickProceedToCheckOutButtonOnAddressPage()
                               .VerifyShippingBlock()
                               .ClickTermsTitle()
                               .ClickProceedToCheckOutOnShippingPage()
                               .ClickPayByWireLink()
                               .ClickConfirmOrderButton()
                               .VerifyOrderConfirmation()
                               .ClickLogOutButton();

        }

        [TestMethod]
        [TestCategory("Automation Practice")]
        public void TestReviewPreviousItems()
        {
            string date = DateTime.Today.ToString("dd/MM/yyyy");
            string orderMessage = "Order is not as mentioned in the description";
            string paymentMethod = "PayPal";

            var loginPage = login.ClickSIgnInLInk()
                                 .EnterEmailID(EmailID, "Email ID")
                                 .EnterPassword(Password, "Password")
                                 .ClickLoginButton()
                                 .ClickOrderHistoryButton()
                                 .ClickOrderLink(date)
                                 .ChooseOrderFromDropDown()
                                 .EnterMessage(orderMessage)
                                 .ClickSendButton()
                                 .VerifyMessageIsSaved(orderMessage)
                                 .VerifyPaymentMethod(paymentMethod);

        }
        [TestCleanup]
        public void TestCleanup()
        {
            BaseTestCleanup();
        }
    }
}
