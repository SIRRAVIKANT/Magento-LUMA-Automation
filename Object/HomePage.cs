using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace LumaAutomation.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }
 
        private IWebElement SignInButton => Driver.FindElement(By.LinkText("Sign In"));
        private IWebElement CreateAccountButton => Driver.FindElement(By.LinkText("Create an Account"));
        private IWebElement WelcomeText => Driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[1]/span"));
        private WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public void ClickSignIn()
        {
            SignInButton.Click();
        }

        public void ClickCreateAccount()
        {
            CreateAccountButton.Click();
        }

        public bool IsHeaderVisible(string header)
        {
            return Driver.PageSource.Contains(header);
        }
         public bool IsExistingAccountMessageVisible()
        {
            try
            {
                var existingAccountMessageElement = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'There is already an account with this email address.')]")));
                return existingAccountMessageElement.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
public string GetExistingAccountMessage()
        {
            try
            {
                var existingAccountMessageElement = Driver.FindElement(By.XPath("//div[contains(text(), 'There is already an account with this email address.')]"));
                return existingAccountMessageElement.Text;
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException("Existing account message element not found.");
            }
        }
        public bool IsWelcomeText()
        {
            try
            {
                return WelcomeText.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

       public bool IsSuccessMessageVisible(string expectedMessage)
        {
            try
            {
                var successMessageElement = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//div[contains(text(), '{expectedMessage}')]")));
                return successMessageElement.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }


         public string GetSuccessMessage()
        {
            try
            {
                var successMessageElement = Driver.FindElement(By.XPath("//div[contains(text(), 'Thank you for registering with Main Website Store.')]"));
                return successMessageElement.Text;
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException("Success message element not found.");
            }
        }
    }
}
