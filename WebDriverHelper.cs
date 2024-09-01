using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LumaAutomation.Utils
{
    public class WebDriverHelper
    {
        public static IWebDriver InitializeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}