using APITest.Controllers;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITest.Tests
{
    [TestFixture]
    public class EmployeeTestPositive : EmployeeController
    {
        private static int idForPositive = 1;


        //POSITIVE SCENARIOS
        [Test]
        public async Task TestStatusGetAllEmployee()
        {
            var response = await this.GetEmployeeAsync();
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            string message = Convert.ToString(result["message"]);
            Assert.That(message.Contains("All records has been fetched"));
        }

        [Test]
        public async Task CreateNewEmployee()
        {

            var response = await CreateNewEmployeeAsync();
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            string message = Convert.ToString(result["message"]);
            Assert.That(message.Contains("Record has been added"));
        }

        [Test]
        public async Task CheckAllDataGetAllEmployee()
        {
            var response = await this.GetEmployeeAsync();
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            List<object> data = (List<object>)result["data"];

            var count = data.Count;
            for (int i = 0; i < count; i++)
            {
                var singleJson = JObject.FromObject(data[i]);
                Assert.That(Convert.ToString(singleJson),
                    Contains.Substring("id").And.Contains("employee_name").
                    And.Contains("employee_salary").And.Contains("employee_age").
                    And.Contains("profile_image"));
                Console.WriteLine(singleJson);
            }
        }

        [Test]
        public async Task GetEmployeeById()
        {

            var response = await this.GetEmployeeByIdAsync(idForPositive);
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            Dictionary<string, object> data = (Dictionary<string, object>)result["data"];
            Assert.That(data["id"], Is.EqualTo(idForPositive));
        }

        [Test]
        public async Task UpdateEmployee()
        {
            var response = await this.UpdataDataAboutEmployeeAsync(idForPositive);
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            var message = Convert.ToString(result["message"]);
            Assert.That(message.Contains("Record has been updated"));
        }
        [Test]
        public async Task TestDeleteEmployee()
        {
            var response = await this.DeleteEmployeeAsync(idForPositive);
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            string message = Convert.ToString(result["message"]);
            Assert.That(message.Contains("Record has been deleted"));

        }

        [Test]
        public async Task CreateDeleteGetEmployee()
        {
            var create = await CreateNewEmployeeAsync();

            Dictionary<string, object> resultCreate = (Dictionary<string, object>)create;
            Dictionary<string, object> dataCreate = (Dictionary<string, object>)resultCreate["data"];

            var delete = await this.DeleteEmployeeAsync(Convert.ToInt32(dataCreate["id"]));
            var get = await this.GetEmployeeByIdAsync(Convert.ToInt32(dataCreate["id"]));

            Dictionary<string, object> resultGet = (Dictionary<string, object>)get;
            var dataGet = Convert.ToString(resultGet["data"]);
            Assert.IsEmpty(dataGet);

        }

        [Test]
        public async Task CreateChangeGet()
        {
            var create = await CreateNewEmployeeAsync();

            Dictionary<string, object> resultCreate = (Dictionary<string, object>)create;
            Dictionary<string, object> dataCreate = (Dictionary<string, object>)resultCreate["data"];

            var put = await this.UpdataDataAboutEmployeeAsync(Convert.ToInt32(dataCreate["id"]));
            Dictionary<string, object> resultPut = (Dictionary<string, object>)put;
            Dictionary<string, object> dataPut = (Dictionary<string, object>)resultPut["data"];

            var get = await this.GetEmployeeByIdAsync(Convert.ToInt32(dataPut["id"]));
            Dictionary<string, object> resultGet = (Dictionary<string, object>)get;
            Dictionary<string, object> dataGet = (Dictionary<string, object>)resultGet["data"];


            Assert.That(dataGet["employee_name"], Is.EqualTo(dataPut["employee_name"]));
        }

        [Test]
        public async Task GetChangeGet()
        {
            var get1 = await this.GetEmployeeByIdAsync(idForPositive);
            Dictionary<string, object> resultGet1 = (Dictionary<string, object>)get1;
            Dictionary<string, object> dataGet1 = (Dictionary<string, object>)resultGet1["data"];

            var put = await this.UpdataDataAboutEmployeeAsync(idForPositive);
            Dictionary<string, object> resultPut = (Dictionary<string, object>)put;
            Dictionary<string, object> dataPut = (Dictionary<string, object>)resultPut["data"];

            var get2 = await this.GetEmployeeByIdAsync(idForPositive);
            Dictionary<string, object> resultGet2 = (Dictionary<string, object>)get2;
            Dictionary<string, object> dataGet2 = (Dictionary<string, object>)resultGet2["data"];

            Assert.That(dataGet2["employee_name"],Is.EqualTo(dataPut["employee_name"]).And.Not.EqualTo(dataGet1["employee_name"]));
        }


    }
    public class EmployeeTestNegative : EmployeeController
    {
        private static int idForNegative = 30;
        private static int idForNegativeCreating = 20;
        //NEGATIVE SCENARIOS
        [Test]
        public async Task CreateExistingEmployee()
        {
            var response = await CreateExistingEmployeeAsync(idForNegativeCreating);
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            Dictionary<string, object> data = (Dictionary<string, object>)result["data"];
            Assert.That(data["id"],Is.Not.EqualTo(idForNegativeCreating));
        }

        [Test]
        public async Task GetUnexistingEmployee()
        {
            var response = await this.GetEmployeeByIdAsync(idForNegative);
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            string data = Convert.ToString(result["data"]);
            Assert.IsEmpty(data);
        }

        [Test]
        public async Task UpdateUnexistingEmployee()
        {
            var response = await this.UpdataDataAboutEmployeeAsync(idForNegative);
            Dictionary<string, object> result = (Dictionary<string, object>)response;
            Dictionary<string, object> data = (Dictionary<string, object>)result["data"];
            Assert.That(data["id"], Is.Not.EqualTo(idForNegative));
        }

        [Test]
        public async Task TestDeleteUnexistingEmployee()
        {
            var response = await this.DeleteEmployeeAsync(idForNegative);

            Dictionary<string, object> result = (Dictionary<string, object>)response;
            string status = Convert.ToString(result["status"]);
            Assert.That(status.Contains("error"));
        }

        
    }
}

