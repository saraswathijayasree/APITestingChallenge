Feature: VerifySingleUserDetails

Scenario: Get Details of a single user using GET request and verify the response
	Given I have the url "https://reqres.in/api/users/2"
	When I submit GET user details request
	Then Compare the response with the expected result