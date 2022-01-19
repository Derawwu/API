Feature: Update data about employee

Scenario: Check response status code for PUT request
	When I perform PUT operation, where id = 1
	Then I should get response status = 200

Scenario: Check response Json for PUT Request
	When I perform Put operation, where id = 1
	Then I should get response json with updated data

Scenario: Check response status code for PUT request for unexisting employee
	When I perform PUT operation, where id = 30
	Then I should get response status = 404