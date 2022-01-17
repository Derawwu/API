using APITest.Controllers;
using APITest.Models;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Tests
{
    [TestFixture]
    class DeleteRequest : EmployeeController
    {
        [Test]
        public async Task CheckThatDeleteEmployeeControllerReturnsResponse()
        {
            var response = await this.DeleteEmployeeAsync(1);
            Convert.ToInt32(response.StatusCode).Should().Be(200);
        }

        [Test]
        public async Task CheckThatDeleteEmployeeControllerReturnsCorrectJson()
        {
            int userId = 1;
            var response = await this.DeleteEmployeeAsync(userId);
            var actualResult = JObject.Parse(response.Content).ToObject<Dictionary<string, string>>();
            Convert.ToString(actualResult["data"]).Should().Be($"{userId}");
        }

        [Test]
        public async Task DeleteUnexistingEmployee()
        {
            var response = await this.DeleteEmployeeAsync(100);
            Convert.ToInt32(response.StatusCode).Should().Be(404);
        }
    }
}
