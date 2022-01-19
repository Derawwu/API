using APITest.Controllers;
using FluentAssertions;
using RestSharp;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.Post
{
    [Binding]
    public sealed class CreateEmployeeByIdResponseStatusSteps : EmployeeController
    {
        [When(@"I perform Post by id operarion , where id = (.*)")]
        public async Task WhenIPerformPostByIdOperarionWhereId(int id)
        {
            Response = await this.CreateExistingEmployeeAsync(id);
            StatusCode = Convert.ToInt32(Response.StatusCode);
        }
    }
}
