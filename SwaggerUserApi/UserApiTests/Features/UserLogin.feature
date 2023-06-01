Feature: User Login


@mytag
Scenario: User Login
	Given login path "/user/login"
	When method is GET
	Then logins is successfull and status code is correct
