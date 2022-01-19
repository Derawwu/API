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

namespace SpecFlowApi.Steps.PUT
{
    [Binding]
    public sealed class UpdateAnEmployeeJsonSteps : EmployeeController
    {
        private static EmployeeModel ExpectedResult { get; set; } = new EmployeeModel
        {
            Id = null,
            Employee_name = "Frank Sinatra",
            Employee_age = "188",
            Employee_salary = "200500",
        };
        private static EmployeeModel? ActualResult { get; set; }

        [When(@"I perform Put operation, where id = (.*)")]
        public async Task WhenIPerformPutOperationWhereId(int id)
        {
            ExpectedResult.Id = Convert.ToString(id);
            Response = await this.UpdateDataAboutEmployeeAsync(id);
            ActualResult = JObject.Parse(Response.Content)["data"].ToObject<EmployeeModel>();
        }

        [Then(@"I should get response json with updated data")]
        public void ThenIShouldGetResponseJsonWithUpdatedData()
        {
            WhenIPerformPutOperationWhereId(Convert.ToInt32(ActualResult.Id)).GetAwaiter().GetResult();
            using (new AssertionScope())
            {
                ActualResult.Id.Should().Be(ExpectedResult.Id);
                ActualResult.Employee_name.Should().Be(ExpectedResult.Employee_name);
                ActualResult.Employee_age.Should().Be(ExpectedResult.Employee_age);
                ActualResult.Employee_salary.Should().Be(ExpectedResult.Employee_salary);
            }
        }

    }
}
