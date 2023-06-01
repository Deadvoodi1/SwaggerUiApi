Feature: Create users with array or list
	Create several users with array or list endpoints

@mytag
Scenario: Create users with array endpoint
	Given path "/user/createWithArray"
	And request body for users array
	When method is POST
	Then users are created and response is correct

Scenario: Create users with list endpoint
	Given path "/user/createWithList"
	And request body for users array
	When method is POST
	Then users are created and response is correct