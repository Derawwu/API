using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using APITest.Controllers;
using System.Threading.Tasks;

namespace APITest.Models
{
    public class EmployeeModel : BaseController
    {
        public EmployeeModel()
        {

        }

        public void AssertionEqualityResponseDataAndJsonModel(Dictionary<string, object> expectedJson,
                                                              Dictionary<string, object> expectedDataJson)
        {

            var dataExample = new Dictionary<string, object>()
            {
                ["id"] = "",
                ["employee_name"] = "",
                ["employee_salary"] = "",
                ["employee_age"] = "",
                ["profile_image"] = ""
            };


            var JsonExample = new Dictionary<string, object>()
            {
                ["status"] = "",
                ["data"] = "",
                ["message"] = ""
            };

            Assert.That(expectedJson.Keys, Is.EqualTo(JsonExample.Keys));
            Assert.That(expectedDataJson.Keys, Is.EqualTo(dataExample.Keys));
        }

        public void InfoAboutExistingUser(Dictionary<string, object> expectedDataJson)
        {
            var dataExample = new Dictionary<string, object>()
            {
                ["id"] = 1,
                ["employee_name"] = "Tiger Nixon",
                ["employee_salary"] = 320800,
                ["employee_age"] = 61,
                ["profile_image"] = ""
            };
            Assert.That(Convert.ToString(expectedDataJson.Values).
                Equals(Convert.ToString(dataExample.Values)));
        }

        public async Task<Dictionary<string, object>> DictionaryInitializerCreate(Dictionary<string, object> JsonPairs)
        {
            JsonPairs = new Dictionary<string, object>()
            {
                ["employee_name"] = "Eddie Murphy",
                ["employee_salary"] = "100500",
                ["employee_age"] = "88",
            };
            return JsonPairs;
        }

        public async Task<Dictionary<string, object>> DictionaryInitializerCreateById(Dictionary<string, object> JsonPairs)
        {
            JsonPairs = new Dictionary<string, object>()
            {
                ["id"] = "1",
                ["employee_name"] = "Eddie Murphy",
                ["employee_salary"] = "100500",
                ["employee_age"] = "88",
            };
            return JsonPairs;
        }

        public async Task<Dictionary<string, object>> DictionaryInitializerUpdate(Dictionary<string, object> JsonPairs)
        {
            JsonPairs = new Dictionary<string, object>()
            {
                ["employee_name"] = "Frank Sinatra",
                ["employee_salary"] = "200500",
                ["employee_age"] = "188",
            };
            return JsonPairs;
        }
    }
}
