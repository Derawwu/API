using APITest.Controllers;
using APITest.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.Post
{
    [Binding]
    public sealed class CreateNewEmployeeJsonSteps : EmployeeController
    {
        private static EmployeeModel ExpectedResult { get; set; } = new EmployeeModel
        {
            Employee_name = "Eddie Murphy",
            Employee_age = "88",
            Employee_salary = "100500",
        };
        private static EmployeeModel? ActualResult { get; set; }

        [When(@"I perform Post operarion")]
        public async Task WhenIPerformPostOperarion()
        {
            Response = await this.CreateNewEmployeeAsync();
            ActualResult = JObject.Parse(Response.Content)["data"].ToObject<EmployeeModel>();
        }

        [Then(@"I should get in response message correct Json")]
        public void ThenIShouldGetInResponseMessageCorrectJson()
        {
            WhenIPerformPostOperarion().GetAwaiter().GetResult();
            using (new AssertionScope())
            {
                ActualResult.Employee_name.Should().Be(ExpectedResult.Employee_name);
                ActualResult.Employee_age.Should().Be(ExpectedResult.Employee_age);
                ActualResult.Employee_salary.Should().Be(ExpectedResult.Employee_salary);
            }
        }
    }
}
