using APITest.Controllers;
using APITest.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Tests
{
    [TestFixture]
    class InteractionOfMultipleRequests : EmployeeController
    {
        [Test]
        public async Task CreateDeleteGetEmployee()
        {
            var responseCreate = await this.CreateNewEmployeeAsync();
            var resultCreate = JObject.Parse(responseCreate.Content)["data"].ToObject<EmployeeModel>();
            await this.DeleteEmployeeAsync(Convert.ToInt32(resultCreate.Id));
            var responseGet = await this.GetEmployeeByIdAsync(Convert.ToInt32(resultCreate.Id));
            Convert.ToInt32(responseGet.StatusCode).Should().Be(404);
        }

        [Test]
        public async Task CreateChangeGet()
        {
            
            var responseCreate = await this.CreateNewEmployeeAsync();
            var resultCreate = JObject.Parse(responseCreate.Content)["data"].ToObject<EmployeeModel>();
            await this.UpdateDataAboutEmployeeAsync(Convert.ToInt32(resultCreate.Id));
            var responseGet = await this.GetEmployeeByIdAsync(Convert.ToInt32(resultCreate.Id));
            var actualResult = JObject.Parse(responseGet.Content)["data"].ToObject<EmployeeModel>();
            var expectedResult = new EmployeeModel
            {
                Id = resultCreate.Id,
                Employee_name = "Frank Sinatra",
                Employee_age = "188",
                Employee_salary = "200500",
                Profile_image = null
            };
            using (new AssertionScope())
            {
                resultCreate.Id.Should().Be(expectedResult.Id);
                actualResult.Employee_name.Should().Be(expectedResult.Employee_name);
                actualResult.Employee_age.Should().Be(expectedResult.Employee_age);
                actualResult.Employee_salary.Should().Be(expectedResult.Employee_salary);
                actualResult.Profile_image.Should().Be(expectedResult.Profile_image);
            }
        }

        [Test]
        public async Task ChangeGet()
        {
            
            var responsePut = await this.UpdateDataAboutEmployeeAsync(1);
            var resultPut = JObject.Parse(responsePut.Content)["data"].ToObject<EmployeeModel>();
            var responseGet = await this.GetEmployeeByIdAsync(Convert.ToInt32(resultPut.Id));
            var resultGet = JObject.Parse(responseGet.Content)["data"].ToObject<EmployeeModel>();
            using (new AssertionScope())
            {
                resultPut.Id.Should().Be(resultGet.Id);
                resultPut.Employee_name.Should().Be(resultGet.Employee_name);
                resultPut.Employee_age.Should().Be(resultGet.Employee_age);
                resultPut.Employee_salary.Should().Be(resultGet.Employee_salary);
                resultPut.Profile_image.Should().Be(resultGet.Profile_image);
            }
        }
    }
}
