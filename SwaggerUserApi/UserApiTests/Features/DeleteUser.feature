Feature: Delete User


@mytag
Scenario: Delete user
	Given deleting user "/user/{username}"
	When method is DELETE
	Then user deleted successfully and status code is correct
