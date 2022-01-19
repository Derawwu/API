using APITest.Controllers;
using FluentAssertions;
using RestSharp;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.PUT
{
    [Binding]
    public sealed class UpdateAnEmployeeResponseStatusSteps : EmployeeController
    {

        [When(@"I perform PUT operation, where id = (.*)")]
        public async Task WhenIPerformPUTOperationWhereId(int id)
        {
            Response = await this.UpdateDataAboutEmployeeAsync(id);
            StatusCode = Convert.ToInt32(Response.StatusCode);
        }
    }
}
