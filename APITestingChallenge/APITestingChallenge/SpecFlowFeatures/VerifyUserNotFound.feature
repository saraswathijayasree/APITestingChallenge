Feature: VerifyUserNotFound
	
Scenario: Verify that a User not found response to a GET request is returning a 404
	Given I have the invalid url "https://reqres.in/api/users/23"
	When I submit the GET request
	Then verify the response is 404