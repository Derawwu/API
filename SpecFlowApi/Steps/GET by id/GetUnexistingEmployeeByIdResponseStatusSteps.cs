using APITest.Controllers;
using FluentAssertions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.GET_by_id
{
    [Binding]
    public sealed class GetUnexistingEmployeeByIdResponseStatusSteps : EmployeeController
    { 
        [When(@"I perform GET operation for unexisting employee, where employeeId = (.*)")]
        public async Task WhenIPerformGETOperationForUnexistingEmployeeWhereEmployeeId(int id = 30)
        {
            Response = await this.GetEmployeeByIdAsync(id);
            StatusCode = Convert.ToInt32(Response.StatusCode);
        }  
    }
}
