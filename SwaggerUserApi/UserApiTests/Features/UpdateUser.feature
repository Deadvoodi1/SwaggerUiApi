Feature: Update User

Update a usermane of the selected user

@mytag
Scenario: Update user
	Given update user "/user/{username}"
	And request body
	When method is PUT
	Then username updated successfully and status code is correct
