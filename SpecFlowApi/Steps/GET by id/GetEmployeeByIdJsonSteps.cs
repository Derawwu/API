using APITest.Controllers;
using APITest.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.GET_by_id
{
    [Binding]
    public sealed class GetEmployeeByIdJsonSteps : EmployeeController
    {
        private static EmployeeModel ExpectedResult { get; set; } = new EmployeeModel
        {
            Id = "1",
            Employee_name = "Tiger Nixon",
            Employee_age = "61",
            Employee_salary = "320800",
            Profile_image = ""
        };
        private static EmployeeModel? ActualResult { get; set; }

        [When(@"I perform GET operation for single employee, where employeeId = (.*)")]
        public async Task WhenIPerformGETOperationForSingleEmployeeWhereEmployeeId(int id = 1)
        {
            Response = await this.GetEmployeeByIdAsync(id);
            ActualResult = JObject.Parse(Response.Content)["data"].ToObject<EmployeeModel>();
        }

        [Then(@"I should get correct json with all data about user")]
        public void ThenIShouldGetCorrectJsonWithAllDataAboutUser()
        {
            WhenIPerformGETOperationForSingleEmployeeWhereEmployeeId().GetAwaiter().GetResult();
            using (new AssertionScope())
            {
                ActualResult.Id.Should().Be(ExpectedResult.Id);
                ActualResult.Employee_name.Should().Be(ExpectedResult.Employee_name);
                ActualResult.Employee_age.Should().Be(ExpectedResult.Employee_age);
                ActualResult.Employee_salary.Should().Be(ExpectedResult.Employee_salary);
                ActualResult.Profile_image.Should().Be(ExpectedResult.Profile_image);
            }
        }
    }
}
