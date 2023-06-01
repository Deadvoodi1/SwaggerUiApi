Feature: Get User


@mytag
Scenario: Get user
	Given user "/user/{username}"
	When method is GET
	Then user found and status code is correct
