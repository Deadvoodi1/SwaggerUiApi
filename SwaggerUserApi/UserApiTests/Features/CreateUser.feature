Feature: Create User


@mytag
Scenario: Create user
	Given path "/user"
	And request body
	When method is POST
	Then user is created and response is correct
