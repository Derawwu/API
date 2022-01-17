Feature: Get request

Scenario: Check workability of GET request for one employee

Given I perform GET operation for single employee ,where employeeId = 1
Then I should get response status "200"