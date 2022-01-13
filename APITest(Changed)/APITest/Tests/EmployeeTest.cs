using APITest.Controllers;
using APITest.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APITest.Tests
{
    [TestFixture]
    public class EmployeeTestPositive : BaseController
    {
        private static int idForPositiveTests = 1;
        //POSITIVE SCENARIOS
        [Test]
        public async Task CheckStatusAndStatusMessageGetAllEmployee()
        {
            List<object> response = (List<object>)await this.GetAll();
            var StatusCode = response[2];
            var responseData = (Dictionary<string, object>)response[0];
            Assert.That(responseData["status"], Is.EqualTo("success"));
            Assert.That(StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task TestCreateNewEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var check = await employeeModel.DictionaryInitializerCreate(JsonPairs);
            List<object> response = (List<object>)await CreateNewEmployee();
            var responseData = (Dictionary<string, object>)response[0];
            Dictionary<string, object> rawData = (Dictionary<string, object>)responseData["data"];
            Assert.That(rawData.Keys, Is.SupersetOf(check.Keys));
            Assert.That(rawData.Values, Is.SupersetOf(check.Values));
        }

        [Test]
        public async Task CheckAllDataGetAllEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            List<object> response = (List<object>)await this.GetAll();
            var responseData = (Dictionary<string, object>)response[0];
            List<object> data = (List<object>)responseData["data"];
            foreach (Dictionary<string, object> outputData in data)
            {
                employeeModel.AssertionEqualityResponseDataAndJsonModel(responseData, outputData);
            }
        }

        [Test]
        public async Task CheckStatusCoseAndStatusMessageGetEmployeeById()
        {
            List<object> response = (List<object>)await this.GetEmployeeById(idForPositiveTests);
            var StatusCode = response[2];
            var responseData = (Dictionary<string, object>)response[0];
            Assert.That(responseData["status"], Is.EqualTo("success"));
            Assert.That(StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task VerifyInfoAboutEmployeeById()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            List<object> response = (List<object>)await this.GetEmployeeById(idForPositiveTests);
            var responseData = (Dictionary<string, object>)response[0];
            employeeModel.InfoAboutExistingUser((Dictionary<string, object>)responseData["data"]);
        }

        [Test]
        public async Task CheckStatusCoseAndStatusMessageUpdateEmployee()
        {
            List<object> response = (List<object>)await this.UpdateEmployee(idForPositiveTests);
            var StatusCode = response[2];
            var responseData = (Dictionary<string, object>)response[0];
            Assert.That(responseData["status"], Is.EqualTo("success"));
            Assert.That(StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task CheckDataUpdateEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var check = await employeeModel.DictionaryInitializerUpdate(JsonPairs);
            List<object> response = (List<object>)await UpdateEmployee(idForPositiveTests);
            var responseData = (Dictionary<string, object>)response[0];
            Dictionary<string, object> rawData = (Dictionary<string, object>)responseData["data"];
            Assert.That(rawData.Keys, Is.EqualTo(check.Keys));
            Assert.That(rawData.Values, Is.EqualTo(check.Values));
        }


        [Test]
        public async Task TestDeleteEmployee()
        {
            List<object> response = (List<object>)await this.DeleteEmployee(idForPositiveTests);
            var StatusCode = response[2];
            var responseData = (Dictionary<string, object>)response[0];
            Assert.That(responseData["status"], Is.EqualTo("success"));
            Assert.That(StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task CreateDeleteGetEmployee()
        {
            List<object> response = (List<object>)await CreateNewEmployee();
            var responseData = (Dictionary<string, object>)response[0];
            Dictionary<string, object> data = (Dictionary<string, object>)responseData["data"];
            await this.DeleteEmployee(Convert.ToInt32(data["id"]));
            List<object> responseGet = (List<object>)await this.GetEmployeeById(Convert.ToInt32(data["id"]));
            var responseGetData = (Dictionary<string, object>)responseGet[0];
            Assert.IsNull(responseGetData["data"]);
        }

        [Test]
        public async Task CreateChangeGet()
        {
            List<object> responseCreate = (List<object>)await CreateNewEmployee();
            var resultCreate = (Dictionary<string, object>)responseCreate[0];
            Dictionary<string, object> data = (Dictionary<string, object>)resultCreate["data"];
            var put = (List<object>)await this.UpdateEmployee(Convert.ToInt32(data["id"]));
            var resultPut = (Dictionary<string, object>)put[0];
            Dictionary<string, object> dataPut = (Dictionary<string, object>)resultPut["data"];
            var get = (List<object>)await this.GetEmployeeById(Convert.ToInt32(data["id"]));
            var resultGet = (Dictionary<string, object>)get[0];
            Dictionary<string, object> dataGet = (Dictionary<string, object>)resultGet["data"];
            Assert.That(dataGet, Is.EqualTo(dataPut));
        }
        
        [Test]
        public async Task GetChangeGet()
        {
            var get1 = (List<object>)await this.GetEmployeeById(idForPositiveTests);
            Dictionary<string, object> resultGet1 = (Dictionary<string, object>)get1[0];
            Dictionary<string, object> dataGet1 = (Dictionary<string, object>)resultGet1["data"];

            var put = (List<object>)await this.UpdateEmployee(idForPositiveTests);
            Dictionary<string, object> resultPut = (Dictionary<string, object>)put[0];
            Dictionary<string, object> dataPut = (Dictionary<string, object>)resultPut["data"];

            var get2 = (List<object>)await this.GetEmployeeById(idForPositiveTests);
            Dictionary<string, object> resultGet2 = (Dictionary<string, object>)get2[0];
            Dictionary<string, object> dataGet2 = (Dictionary<string, object>)resultGet2["data"];

            Assert.That(dataGet2["employee_name"], Is.EqualTo(dataPut["employee_name"]).And.Not.EqualTo(dataGet1["employee_name"]));
        }
    }
    public class EmployeeTestNegative : BaseController
    {
        private static int idForNegative = 30;
        private static int idForNegativeCreating = 20;
        //NEGATIVE SCENARIOS
        [Test]
        public async Task CreateExistingEmployee()
        {
            var response = (List<object>)await CreateEmployeeById();
            Dictionary<string, object> result = (Dictionary<string, object>)response[0];
            Dictionary<string, object> data = (Dictionary<string, object>)result["data"];
            Assert.That(data["id"], Is.Not.EqualTo(idForNegativeCreating));
        }

        [Test]
        public async Task GetUnexistingEmployee()
        {
            var response = (List<object>)await this.GetEmployeeById(idForNegative);
            var status = response[2];
            Assert.That((int)status, Is.EqualTo(404));
        }

        [Test]
        public async Task UpdateUnexistingEmployee()
        {
            var response = (List<object>)await this.UpdateEmployee(idForNegative);
            var status = response[2];
            Assert.That((int)status,Is.EqualTo(404));
        }

        [Test]
        public async Task TestDeleteUnexistingEmployee()
        {
            var response = (List<object>)await this.DeleteEmployee(idForNegative);
            var status = response[2];
            Assert.That((int)status, Is.EqualTo(404)); 
        }
    }
}

