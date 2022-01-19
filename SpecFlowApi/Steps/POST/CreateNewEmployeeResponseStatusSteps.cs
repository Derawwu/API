using APITest.Controllers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.Post
{
    [Binding]
    public sealed class CreateNewEmployeeResponseStatusSteps : EmployeeController
    {
        [When(@"I perform POST operation")]
        public async Task WhenIPerformPOSTOperation()
        {
            Response = await this.CreateNewEmployeeAsync();
            StatusCode = Convert.ToInt32(Response.StatusCode);
        }
    }
}
