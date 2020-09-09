Feature: VerifyUsersListDetails

Scenario: Verify that a GET request can be posted to the API to get the expected details of the list of users
 Given I have the url "https://reqres.in/api/users?page=2"
 When I submit GET user details request
 Then Compare the response details of users with the expected result
		