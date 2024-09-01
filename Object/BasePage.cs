using OpenQA.Selenium;

namespace LumaAutomation.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}