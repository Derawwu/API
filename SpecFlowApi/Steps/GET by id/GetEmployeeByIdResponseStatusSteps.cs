using APITest.Controllers;
using FluentAssertions;
using RestSharp;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.GET_by_id
{
    [Binding]
    public sealed class GetEmployeeByIdResponseStatusSteps : EmployeeController
    {
        [When(@"I perform GET operation for single employee ,where employeeId = (.*)")]
        public async Task GivenIPerformGETOperationForSingleEmployeeWhereEmployeeId(int id = 1)
        {
            Response = await this.GetEmployeeByIdAsync(id);
            StatusCode = Convert.ToInt32(Response.StatusCode);
        }


        [Then(@"I should get response status = (.*)")]
        public void ThenIShouldGetResponseStatus(int statusOK)
        {
            GivenIPerformGETOperationForSingleEmployeeWhereEmployeeId().GetAwaiter().GetResult();
            StatusCode.Should().Be(statusOK);
        }
    }
}
