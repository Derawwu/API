Feature: Delete employee

Scenario: Check response status code for DELETE request
	When I perform DELETE operation, where id = 1
	Then I should get response status = 200

Scenario: Check response Json for DELETE request
	When I perform Delete operation, where id = 1
	Then I should get approrpiate json response

Scenario: Check response status code for DELETE request for unexisting employee
	When I perform DELETE operation, where id = 30
	Then I should get response status = 404
