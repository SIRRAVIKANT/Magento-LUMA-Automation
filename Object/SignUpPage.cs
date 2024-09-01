using OpenQA.Selenium;

namespace LumaAutomation.Pages
{
    public class SignUpPage : BasePage
    {
        public SignUpPage(IWebDriver driver) : base(driver) { }

        private IWebElement FirstNameField => Driver.FindElement(By.Id("firstname"));
        private IWebElement LastNameField => Driver.FindElement(By.Id("lastname"));
        private IWebElement EmailField => Driver.FindElement(By.Id("email_address"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        private IWebElement ConfirmPasswordField => Driver.FindElement(By.Id("password-confirmation"));
        private IWebElement CreateAccountButton => Driver.FindElement(By.CssSelector("button[title='Create an Account']"));

        public void EnterFirstName(string firstName)
        {
            FirstNameField.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LastNameField.SendKeys(lastName);
        }

        public void EnterEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            ConfirmPasswordField.SendKeys(confirmPassword);
        }

        public void ClickCreateAccount()
        {
            CreateAccountButton.Click();
        }
    }
}