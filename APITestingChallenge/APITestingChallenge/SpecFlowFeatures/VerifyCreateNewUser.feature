Feature: VerifyCreateNewUser

Scenario: Create a single user and assert that the single user is created 
	Given I input the name "morpheus"
	And I input role "leader"
	When I Post Create User request
	Then verfy that the user is created successfully