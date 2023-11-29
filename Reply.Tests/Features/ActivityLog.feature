Feature: ActivityLog

Scenario: Delete activity log
	Given I am on activity log page
	When I delete first 3 items in the table
	Then the items should not be present
