using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LumaStoreProject
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = new ChromeDriver(); // Initialize here to avoid CS8618 warning
            _driver.Manage().Window.Maximize();
            _scenarioContext.Set(_driver); 
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            _scenarioContext["WebDriver"] = _driver;
        }

        [AfterScenario]
        public void TearDownWebDriver()
        {
            if (_driver != null)
            {
                Thread.Sleep(20000); //just to watch last result in UI.
                _driver.Quit();
            }
        }
    }
}
