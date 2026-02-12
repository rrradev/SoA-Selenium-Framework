Feature: Users page UI tests
    
    
    Scenario: Verify newly created users are displayed in the users list
        Given user is created successfully
        When I login with valid credentials
        And I navigate to the users page
        Then the user should be displayed in table of user list