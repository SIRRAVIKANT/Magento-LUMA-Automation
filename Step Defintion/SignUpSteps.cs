using LumaAutomation.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using NUnit.Framework;


namespace LumaAutomation.Steps
{
    [Binding]
    public class SignUpSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly SignUpPage _signUpPage;

        public SignUpSteps(ScenarioContext scenarioContext)
        {
            try
            {
                _driver = scenarioContext.Get<IWebDriver>();
                _homePage = new HomePage(_driver);
                _signUpPage = new SignUpPage(_driver);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to initialize SignUpSteps.", ex);
            }
        }

        [Given(@"I am on the LUMA homepage")]
        public void GivenIAmOnTheLUMAHomepage()
        {
            try
            {
                _homePage.NavigateTo("https://magento.softwaretestingboard.com/");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to navigate to LUMA homepage.", ex);
            }
        }

        [Given(@"I click on the 'Create an Account' button")]
        public void GivenIClickOnTheCreateAnAccountButton()
        {
            try
            {
                _homePage.ClickCreateAccount();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to click on 'Create an Account' button.", ex);
            }
        }

        [Then(@"I should see the 'Create New Customer Account' header")]
        public void ThenIShouldSeeTheCreateNewCustomerAccountHeader()
        {
            try
            {
                bool isHeaderVisible = _homePage.IsHeaderVisible("Create New Customer Account");
                if (!isHeaderVisible)
                {
                    throw new InvalidOperationException("Create New Customer Account header is not visible.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error checking 'Create New Customer Account' header visibility.", ex);
            }
        }

        [When(@"I fill in the signup form with the following details")]
        public void WhenIFillInTheSignupFormWithTheFollowingDetails(Table table)
        {
            try
            {
                foreach (var row in table.Rows)
                {
                    _signUpPage.EnterFirstName(row["FirstName"]);
                    _signUpPage.EnterLastName(row["LastName"]);
                    _signUpPage.EnterEmail(row["Email"]);
                    _signUpPage.EnterPassword(row["Password"]);
                    _signUpPage.EnterConfirmPassword(row["ConfirmPassword"]);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to fill in the signup form.", ex);
            }
        }

        [When(@"I click on the 'Create' button")]
        public void WhenIClickOnTheCreateButton()
        {
            try
            {
                _signUpPage.ClickCreateAccount();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to click on 'Create' button.", ex);
            }
        }
 [Then(@"I should be signed up successfully with '(.*)' message")]
        public void ThenIShouldBeSignedUpSuccessfullyWithMessage(string expectedSuccessMessage)
        {
            try
            {
                bool isSuccessMessageVisible = _homePage.IsSuccessMessageVisible(expectedSuccessMessage);
                if (isSuccessMessageVisible)
                {
                    string actualSuccessMessage = _homePage.GetSuccessMessage();
                    if (actualSuccessMessage != expectedSuccessMessage)
                    {
                        throw new InvalidOperationException("Success message does not match the expected text.");
                    }
                }
                else
                {
                    bool isExistingAccountMessageVisible = _homePage.IsExistingAccountMessageVisible();
                    if (isExistingAccountMessageVisible)
                    {
                        string actualExistingAccountMessage = _homePage.GetExistingAccountMessage();
                        if (actualExistingAccountMessage != "There is already an account with this email address. If you are sure that it is your email address, click here to get your password and access your account.")
                        {
                            throw new InvalidOperationException("Existing account message does not match the expected text.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Neither the success message nor the existing account message is visible.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error verifying signup messages.", ex);
            }
        }
    
    }
}
