Feature: Users API tests
    CRUD operations for users endpoints

    Scenario: Get users by id retuns the corrrect user
        Given I make a get request to users endpoint with id 1
        Then the response status code should be 200
        And users response should contain the following data:
          | Id | FirstName | Password |
          | 1  | AdminAA   | pass123  |

    Scenario: Get users by id retuns the corrrect error for invalid user ID
        Given I make a get request to users endpoint with id 0
        Then the response status code should be 404
        And the response should contain the following error message "User not found"
        
    Scenario: Create user with valid data returns the created user
        Given I make a post request to users endpoint with the following data:
          |Field     | Value                |
          |--------- |----------------------|
          | FirstName | Ivan                |
          | Password  | pass123             |
          | Email     | ivan@automation.com |
          | City      | Sofia               |
          | Country   | Bulgaria            |
          | IsAdmin   | 0                   |
          | SirName   | Ivanov              |
          | Title     | Mr.                 |
        Then the response status code should be 200
        And create users response should contain the following data:
          | Field     | Value                  |
          | --------- | ---------------------- |
          | FirstName | Ivan                   |
          | City      | Sofia                  |
          | Country   | Bulgaria               |
          | IsAdmin   | 0                      |
          | SirName   | Ivanov                 |
          | Title     | Mr.                    |