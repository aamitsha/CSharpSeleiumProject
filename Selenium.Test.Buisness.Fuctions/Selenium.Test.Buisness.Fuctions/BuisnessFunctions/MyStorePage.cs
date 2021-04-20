using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Buisness.Fuctions.BuisnessFunctions
{
    public class MyStorePage : BasePage
    {
        public MyStorePage(IWebDriver driver) : base(driver)
        {

        }

        private By ProductSearchBox => By.Id("search_query_top");
        private By SearchProductButton => By.XPath("//button[@name='submit_search']");
        private By ProductLink(string productTitle, string productLink) => By.XPath("//a[@class='product-name'][@title='" + productTitle + "'][@href='" + productLink + "']");
        private By OrderHistoryButton => By.XPath("//span[text()='Order history and details']");

        public MyStorePage SearchProduct(string productName)
        {
            EnterText(ProductSearchBox, productName, "Product Name");
            return this;
        }
        public MyStorePage ClickSearchProductButton()
        {
            Click(SearchProductButton, "SearchProductButton");
            return this;
        }
        public ProductPage ClickOnProductLink(string productName, string productLink)
        {
            Click(ProductLink(productName, productLink), "Product Link");
            return new ProductPage(driver);
        }
        public OrderHistoryPage ClickOrderHistoryButton()
        {
            Click(OrderHistoryButton, "OrderHistoryButton");
            return new OrderHistoryPage(driver);
        }
    }


}
