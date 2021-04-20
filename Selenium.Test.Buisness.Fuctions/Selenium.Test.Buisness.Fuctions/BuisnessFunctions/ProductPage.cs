using OpenQA.Selenium;
using Selenium.Test.Common.Function.PageFuctions;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.UI;


namespace Selenium.Test.Buisness.Fuctions.BuisnessFunctions
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        private By AddToCartButton => By.XPath("//p[@id='add_to_cart']//button");
        private By ContinueShoppinButton => By.XPath("//span[@title='Continue shopping']");
        private By ProductDescription(string productTitle, string description) => By.XPath("//a[@title='" + productTitle + "']//parent::h5//following-sibling::p[@class='product-desc'][contains(text(),'" + description + "')]");
        private By ProceedToCheckoutButton => By.XPath("//a[@title='Proceed to checkout']");

        public ProductPage SelectSize(Enum size)
        {
            string productSize = size.ToString();
            IWebElement element = driver.FindElement(By.XPath("//select[@id='group_1']"));
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(productSize);
            return this;
        }
        public ProductPage ClickAddToCartButton()
        {
            Click(AddToCartButton, "AddToCartButton");
            return this;
        }
        public MyStorePage ClickContinueShoppingButton()
        {
            Click(ContinueShoppinButton, "ContinueShoppinButton");
            return new MyStorePage(driver);
        }
        public ProductPage VerifyCorrectProductIsDisplayed(string productTitle, string description)
        {
            Assertions.AssetIsTrue(IsElementDisplayed(ProductDescription(productTitle, description)), "Wrong Product");
            return this;
        }
        public OrderPage ClickPreceedToCheckOutButton()
        {
            Click(ProceedToCheckoutButton, "ProceedToCheckoutButton");
            return new OrderPage(driver);
        }
        public string GetProductPrice()
        {
            string productPrice = driver.FindElement(By.XPath("//span[@id='our_price_display']")).Text;
            return productPrice;
        }

    }
}
