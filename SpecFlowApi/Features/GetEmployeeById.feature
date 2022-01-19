Feature: Get by id request

Scenario: Check workability of GET request for one employee
When I perform GET operation for single employee ,where employeeId = 1
Then I should get response status = 200

Scenario: Check response json of GET request for one employee
When I perform GET operation for single employee, where employeeId = 1
Then I should get correct json with all data about user

Scenario: An effort to get unexisting employee
When I perform GET operation for unexisting employee, where employeeId = 30 
Then I should get response status = 404