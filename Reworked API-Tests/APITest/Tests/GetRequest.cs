using APITest.Controllers;
using APITest.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITest.Tests
{
    [TestFixture]
    class GetEmployeeRequest : EmployeeController
    {
        [Test]

        public async Task CheckThatGetAllEmployeeControllerReturnsResponse()
        {
            var response = await this.GetEmployeeAsync();
            Convert.ToInt32(response.StatusCode).Should().Be(200);
        }

        [Test]
        public async Task CheckThatGetAllEmployeeControllerReturnsCorrectJson()
        {
            var expectedResult = (Dictionary<string, string>)new EmployeeModel();
            var response = await this.GetEmployeeAsync();
            var deserialize = new RestSharp.Serialization.Json.JsonDeserializer();
            var deserializedResponce = deserialize.Deserialize<Dictionary<string, object>>(response);
            List<object> data = (List<object>)deserializedResponce["data"];
            foreach (Dictionary<string, object> singleUserData in data)
            {
                expectedResult.Keys.Should().BeEquivalentTo(singleUserData.Keys);
            }

        }

        [Test]
        public async Task CheckThatGetEmployeeByIdControllerReturnsResponse()
        {
            var response = await this.GetEmployeeByIdAsync(1);
            Convert.ToInt32(response.StatusCode).Should().Be(200);
        }

        [Test]
        public async Task CheckThatGetEmployeeByIdControllerReturnsActualData()
        {
            var expectedResult = new EmployeeModel
            {
                Id = "1",
                Employee_name = "Tiger Nixon",
                Employee_age = "61",
                Employee_salary = "320800",
                Profile_image = ""
            };
            var response = await this.GetEmployeeByIdAsync(1);
            var actualResult = JObject.Parse(response.Content)["data"].ToObject<EmployeeModel>();
            using (new AssertionScope())
            {
                actualResult.Id.Should().Be(expectedResult.Id);
                actualResult.Employee_name.Should().Be(expectedResult.Employee_name);
                actualResult.Employee_age.Should().Be(expectedResult.Employee_age);
                actualResult.Employee_salary.Should().Be(expectedResult.Employee_salary);
                actualResult.Profile_image.Should().Be(expectedResult.Profile_image);
            }
        }

        [Test]
        public async Task GetUnexistingEmployeeById()
        {
            var response = await this.GetEmployeeByIdAsync(100);
            Convert.ToInt32(response.StatusCode).Should().Be(404);
        }
    }
}
