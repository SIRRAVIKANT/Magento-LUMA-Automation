using OpenQA.Selenium;

namespace LumaAutomation.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver) { }

        private IWebElement EmailField => Driver.FindElement(By.Id("email"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("pass"));
        private IWebElement SignInButton => Driver.FindElement(By.Id("send2"));

        public void EnterEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickSignIn()
        {
            SignInButton.Click();
        }
    }
}