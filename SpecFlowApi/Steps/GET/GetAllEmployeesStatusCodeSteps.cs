using APITest.Controllers;
using RestSharp;
using System;

using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.GET
{
    [Binding]
    public sealed class GetAllEmployeesStatusCodeSteps : EmployeeController
    {

        [When(@"I perform GET operation")]
        public async Task WhenIPerformGETOperation()
        {
            Response = await this.GetEmployeeAsync();
            StatusCode = Convert.ToInt32(Response.StatusCode);
        }
    }
}
