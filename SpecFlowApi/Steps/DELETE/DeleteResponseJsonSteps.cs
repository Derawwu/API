using APITest.Controllers;
using APITest.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.DELETE
{
    [Binding]
    public sealed class DeleteResponseJsonSteps : EmployeeController
    {
        private static object? ActualResult { get; set; }
        private static object? ExpectedResult { get; set; } = null;
        private static int Id;

        [When(@"I perform Delete operation, where id = (.*)")]
        public async Task WhenIPerformDeleteOperationWhereId(int id)
        {
            Id = id;
            Response = await this.DeleteEmployeeAsync(Id);
            ActualResult = JObject.Parse(Response.Content)["data"];
        }

        [Then(@"I should get approrpiate json response")]
        public void ThenIShouldGetApprorpiateJsonResponse()
        {
            WhenIPerformDeleteOperationWhereId(Id).GetAwaiter().GetResult();
            ExpectedResult.Should().BeEquivalentTo(ActualResult);
        }

    }
}
