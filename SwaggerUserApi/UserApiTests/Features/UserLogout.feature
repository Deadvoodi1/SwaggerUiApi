Feature: User Logout


@mytag
Scenario: User Logout
	Given logout path "/user/logout"
	When method is GET
	Then logout is successfull and status code is correct
