Feature: Contacts

Scenario: Create contact
	Given I am on Contacts page
	When I create a new contact
	Then the contact data should match with entered data
