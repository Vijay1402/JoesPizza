Feature: Pizza Controller Flow

@mytag
Scenario: Verify flow between three different views
    Given the user is on the first view
    When the user performs some action
    Then the user should be on the second view
    When the user performs another action
    Then the user should be on the third view
