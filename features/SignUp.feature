Feature: User SignUp

  Scenario: Successful SignUp
    Given I am on the LUMA homepage
    And I click on the 'Create an Account' button
    Then I should see the 'Create New Customer Account' header
    When I fill in the signup form with the following details
      | FirstName | LastName | Email                 | Password   | ConfirmPassword |
      | Ravi      | Kant     | ravsikant7@gmail.com  | Welcome@123| Welcome@123     |
    And I click on the 'Create' button
    Then I should be signed up successfully with 'Thank you for registering with Main Website Store.' message
