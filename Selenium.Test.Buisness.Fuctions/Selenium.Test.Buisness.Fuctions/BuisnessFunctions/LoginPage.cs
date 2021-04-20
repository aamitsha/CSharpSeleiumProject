using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.Buisness.Fuctions.BuisnessFunctions
{
    public class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }
        #region
        By SIgnInLink => By.XPath("//a[@title='Log in to your customer account']");
        By EmailTextBox => By.XPath("//input[@id='email']");
        By PasswordTextBox => By.XPath("//input[@id='passwd']");
        By LoginButton => By.XPath("//button[@id='SubmitLogin']");
        #endregion

        public LoginPage ClickSIgnInLInk()
        {
            Click(SIgnInLink, "Signin Link");
            return this;
        }
        public LoginPage EnterEmailID(string emailID, string message)
        {
            EnterText(EmailTextBox, emailID, message);
            return this;
        }
        public LoginPage EnterPassword(string password, string message)
        {
            EnterText(PasswordTextBox, password, message);
            return this;
        }
        public MyStorePage ClickLoginButton()
        {
            Click(LoginButton, "Login Button");
            return new MyStorePage(driver);
        }


    }
}
