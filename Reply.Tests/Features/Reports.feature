Feature: Reports

Scenario: Run Project Profitability report
	Given I am on Reports page
	When I run 'Project Profitability' report
	Then the I should see some results
