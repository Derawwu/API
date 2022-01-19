using APITest.Controllers;
using APITest.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Text.Json;

#pragma warning disable CS8604 // Possible null reference argument.

namespace SpecFlowApi.Steps.GET
{
    [Binding]
    public sealed class GetAllEmployeesJson : EmployeeController
    {
        private static List<Dictionary<string, object>>? Data { get; set; }

        [When(@"I perform GET operation for all employees")]
        public async Task WhenIPerformGETOperationForAllEmployees()
        {
            Response = await this.GetEmployeeAsync();
            var Json = JToken.Parse(JObject.Parse(Response.Content).ToString());
            var tokens = Json.SelectToken("data").Children();
            List<Dictionary<string, object>> result = new();
            foreach (var value in tokens)
            {

                result.Add(JObject.Parse(value.ToString()).ToObject<Dictionary<string, object>>());

            }
            Data = result;
        }

        [Then(@"I should get correct json with data about users")]
        public void ThenIShouldGetCorrectJsonWithDataAboutUsers()
        {
            WhenIPerformGETOperationForAllEmployees().GetAwaiter().GetResult();
            var expectedResult = (Dictionary<string, string>)new EmployeeModel();
             foreach (Dictionary<string, object> singleUserData in Data)
             {
                 expectedResult.Keys.Should().BeEquivalentTo(singleUserData.Keys);
             }
        }
    }
}
