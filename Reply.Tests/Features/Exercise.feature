Feature: All features related to the Reply exercise tasks

Scenario: Create contact
	Given I am on Contacts page
	When I create a new contact
	Then the contact data should match with entered data
