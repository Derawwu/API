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
    class PutRequest : EmployeeController
    {
        [Test]
        public async Task CheckThatUpdateDataAboutEmployeeControllerReturnsResponse()
        {
            var response = await this.UpdateDataAboutEmployeeAsync(1);
            Convert.ToInt32(response.StatusCode).Should().Be(200);
        }

        [Test]
        public async Task CheckThatUpdateDataAboutEmployeeControllerReturnsCorrectJson()
        {
            var expectedResult = new EmployeeModel
            {
                Id = "1",
                Employee_name = "Frank Sinatra",
                Employee_age = "188",
                Employee_salary = "200500",
                Profile_image = null
            };
            var response = await this.UpdateDataAboutEmployeeAsync(1);
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
        public async Task UpdateUnexistingEmployee()
        {
            var response = await this.UpdateDataAboutEmployeeAsync(100);
            Convert.ToInt32(response.StatusCode).Should().Be(404);
        }
    }
}
