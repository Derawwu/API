Feature: Create an employee

Scenario: Check response status code for POST request
	When I perform POST operation
	Then I should get response status = 201

Scenario:  Check response Json for Post request
	When I perform Post operarion 
	Then I should get in response message correct Json

Scenario: Check responce status code for POST by id request 
	When I perform Post by id operarion , where id = 1
	Then I should get response status = 201

Scenario:Check response Json for Post by id request
	When I perform POST by id operarion , where id = 1
	Then I should get in response message correct Json if creating employee by id