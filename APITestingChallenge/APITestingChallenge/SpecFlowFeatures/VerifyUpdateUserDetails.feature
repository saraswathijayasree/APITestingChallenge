Feature: VerifyUpdateUserDetails
	
Scenario: Update a single user details with PUT request and Verify
	Given I input the name as "morpheus"
	And I input job "tester"
	When I PUT request to update a user detail
	Then Verify the status code and check updated details