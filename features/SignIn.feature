Feature: User SignIn

  Scenario: Successful SignIn
    Given I am on the LUMA homepage
    And I click on the 'Sign In' button
    Then I should see the 'Customer Login' header
    When I fill in the signin form with the following details
      | Email               | Password   |
      | thirdkant@gmail.com | Welcome@123|
    And I click on the 'Sign In' button
    Then I should be signed in successfully