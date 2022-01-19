Feature: Get all employees

Scenario: Check workability of GET for all employees
	When I perform GET operation 
	Then I should get response status = 200

Scenario: Check response json of GET request for all employees
When I perform GET operation for all employees
Then I should get correct json with data about users