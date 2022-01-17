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
    class PostRequest : EmployeeController
    {
        [Test]
        public async Task CheckThatCreateNewEmployeeControllerReturnsResponse()
        {
            var response = await this.CreateNewEmployeeAsync();
            Convert.ToInt32(response.StatusCode).Should().Be(201);
        }

        [Test]
        public async Task CheckThatCreateNewEmployeeControllerReturnsCorrectJson()
        {
            var expectedResult = new EmployeeModel
            {
                Employee_name = "Eddie Murphy",
                Employee_age = "88",
                Employee_salary = "100500",
                Profile_image = null
            };
            var response = await this.CreateNewEmployeeAsync();
            var actualResult = JObject.Parse(response.Content)["data"].ToObject<EmployeeModel>();
            using (new AssertionScope())
            {
                actualResult.Employee_name.Should().BeEquivalentTo(expectedResult.Employee_name);
                actualResult.Employee_salary.Should().BeEquivalentTo(expectedResult.Employee_salary);
                actualResult.Employee_age.Should().BeEquivalentTo(expectedResult.Employee_age);
                actualResult.Profile_image.Should().BeEquivalentTo(expectedResult.Profile_image);
            }

        }

        [Test]
        public async Task CheckThatCreateEmployeeByIdControllerReturnsResponse()
        {
            var response = await this.CreateExistingEmployeeAsync(1);
            Convert.ToInt32(response.StatusCode).Should().Be(201);
        }

        [Test]
        public async Task CheckThatCreateEmployeeByIdControllerReturnsCorrectJson()
        {
            var expectedResult = new EmployeeModel
            {
                Id = "1",
                Employee_name = "Eddie Murphy",
                Employee_age = "88",
                Employee_salary = "100500",
                Profile_image = null
            };
            var response = await this.CreateExistingEmployeeAsync(1);
            var actualResult = JObject.Parse(response.Content)["data"].ToObject<EmployeeModel>();
            using (new AssertionScope())
            {
                actualResult.Id.Should().BeEquivalentTo(expectedResult.Id);
                actualResult.Employee_name.Should().BeEquivalentTo(expectedResult.Employee_name);
                actualResult.Employee_salary.Should().BeEquivalentTo(expectedResult.Employee_salary);
                actualResult.Employee_age.Should().BeEquivalentTo(expectedResult.Employee_age);
                actualResult.Profile_image.Should().BeEquivalentTo(expectedResult.Profile_image);
            }

        }
    }
}
