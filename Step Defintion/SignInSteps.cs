using LumaAutomation.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;

namespace LumaAutomation.Steps
{
    [Binding]
    public class SignInSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly SignInPage _signInPage;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>();
            _homePage = new HomePage(_driver);
            _signInPage = new SignInPage(_driver);
        }
    
        [Given(@"I click on the 'Sign In' button")]
        public void GivenIClickOnTheSignInButton()
        {
            _homePage.ClickSignIn();
        }

        [Then(@"I should see the 'Customer Login' header")]
        public void ThenIShouldSeeTheCustomerLoginHeader()
        {
            bool isHeaderVisible = _homePage.IsHeaderVisible("Customer Login");
            if (!isHeaderVisible)
            {
                throw new Exception("Customer Login header is not visible");
            }
        }

        [When(@"I fill in the signin form with the following details")]
        public void WhenIFillInTheSigninFormWithTheFollowingDetails(Table table)
        {
            foreach (var row in table.Rows)
            {
                _signInPage.EnterEmail(row["Email"]);
                _signInPage.EnterPassword(row["Password"]);
            }
        }

        [When(@"I click on the 'Sign In' button")]
        public void WhenIClickOnTheSignInButton()
        {
            _signInPage.ClickSignIn();
        }

       [Then(@"I should be signed in successfully")]
        public void ThenIShouldBeSignedInSuccessfully()
        {
            bool isLoggedIn = _homePage.IsWelcomeText();
            if (!isLoggedIn)
            {
                throw new Exception("Sign In failed, 'Sign Out' button is not visible.");
            }
        }
    }
}