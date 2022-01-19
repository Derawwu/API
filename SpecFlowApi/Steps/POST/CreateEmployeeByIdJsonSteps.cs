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
    public sealed class CreateEmployeeByIdJsonSteps : EmployeeController
    {
        private static EmployeeModel ExpectedResult { get; set; } = new EmployeeModel
        {
            Id = null,
            Employee_name = "Eddie Murphy",
            Employee_age = "88",
            Employee_salary = "100500",
            Profile_image = null
        };
        private static EmployeeModel? ActualResult { get; set; }

        [When(@"I perform POST by id operarion , where id = (.*)")]
        public async Task WhenIPerformPOSTByIdOperarionWhereId(int id)
        {
            ExpectedResult.Id =Convert.ToString(id) ;
            Response = await this.CreateExistingEmployeeAsync(id);
            ActualResult = JObject.Parse(Response.Content)["data"]
                                  .ToObject<EmployeeModel>();
        }

        [Then(@"I should get in response message correct Json if creating employee by id")]
        public void ThenIShouldGetInResponseMessageCorrectJsonIfCreatingEmployeeById()
        {
            WhenIPerformPOSTByIdOperarionWhereId(Convert.ToInt32(ExpectedResult.Id)).GetAwaiter().GetResult();
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
