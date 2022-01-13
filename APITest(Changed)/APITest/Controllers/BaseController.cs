using APITest.Constants;
using APITest.Managers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using APITest.Models;

namespace APITest.Controllers
{
    public class BaseController : ConfigManager
    {
        private const string GetEmployeeUrl = "/employees";
        private const string GetEmployeeByIdUrl = "/employee/{0}";
        private const string CreateEmployee = "/create";
        private const string PutEmployee = "/update/{0}";
        private const string RemoveEmployee = "/delete/{0}";
        protected Dictionary<string, object> JsonPairs;
        protected string BaseUrl => Config[ConfigConstants.BaseUrl];
        protected RestClient RestClient => new RestClient(this.BaseUrl);

        

        

        protected async Task<object> GetAll()
        {
            var resource = string.Join(this.BaseUrl, string.Format(GetEmployeeUrl));
            var request = new RestRequest(resource, Method.GET);
            var response = RestClient.Execute(request);
            var status = response.StatusCode;
            var intStatus = Convert.ToInt32(status);
            RestResponse restResponse = (RestResponse)response;
            List<object> result = new List<object>();
            var deserialize = new RestSharp.Serialization.Json.JsonDeserializer();
            var restObject = deserialize.Deserialize<Dictionary<string, object>>(response);
            result.Add(restObject);
            result.Add(restResponse);
            result.Add(intStatus);
            return result;

        }

        protected async Task<object> GetEmployeeById(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(GetEmployeeByIdUrl, employeeId));
            var request = new RestRequest(resource, Method.GET);
            var response = RestClient.Execute(request);
            var status = response.StatusCode;
            var intStatus = Convert.ToInt32(status);
            RestResponse restResponse = (RestResponse)response;
            List<object> result = new List<object>();
            var deserialize = new RestSharp.Serialization.Json.JsonDeserializer();
            var restObject = deserialize.Deserialize<Dictionary<string, object>>(response);
            result.Add(restObject);
            result.Add(restResponse);
            result.Add(intStatus);
            return result;
        }

        protected async Task<object> CreateNewEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            string resource = string.Join(this.BaseUrl, string.Format(CreateEmployee));
            var request = new RestRequest(resource, Method.POST);
            var initialized = await employeeModel.DictionaryInitializerCreate(JsonPairs);//simple creation
            var jsonBody = JsonSerializer.Serialize(initialized);
            request.AddJsonBody(jsonBody);
            var response = RestClient.Execute(request);
            var status = response.StatusCode;
            var intStatus = Convert.ToInt32(status);
            RestResponse restResponse = (RestResponse)response;
            List<object> result = new List<object>();
            var deserialize = new RestSharp.Serialization.Json.JsonDeserializer();
            var restObject = deserialize.Deserialize<Dictionary<string, object>>(response);
            result.Add(restObject);
            result.Add(restResponse);
            result.Add(intStatus);
            return result;
        }

        protected async Task<object> CreateEmployeeById()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            string resource = string.Join(this.BaseUrl, string.Format(CreateEmployee));
            var request = new RestRequest(resource, Method.POST);
            var initialized = await employeeModel.DictionaryInitializerCreateById(JsonPairs);//creation by id
            var jsonBody = JsonSerializer.Serialize(initialized);
            request.AddJsonBody(jsonBody);
            var response = RestClient.Execute(request);
            var status = response.StatusCode;
            var intStatus = Convert.ToInt32(status);
            RestResponse restResponse = (RestResponse)response;
            List<object> result = new List<object>();
            var deserialize = new RestSharp.Serialization.Json.JsonDeserializer();
            var restObject = deserialize.Deserialize<Dictionary<string, object>>(response);
            result.Add(restObject);
            result.Add(restResponse);
            result.Add(intStatus);
            return result;
        }

        protected async Task<object> UpdateEmployee(int employeeId)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var resource = string.Join(this.BaseUrl, string.Format(PutEmployee, employeeId));
            var request = new RestRequest(resource, Method.PUT);
            var initialized = await employeeModel.DictionaryInitializerUpdate(JsonPairs);
            var jsonBody = JsonSerializer.Serialize(initialized);
            request.AddJsonBody(jsonBody);
            var response = RestClient.Execute(request);
            var status = response.StatusCode;
            var intStatus = Convert.ToInt32(status);
            RestResponse restResponse = (RestResponse)response;
            List<object> result = new List<object>();
            var deserialize = new RestSharp.Serialization.Json.JsonDeserializer();
            var restObject = deserialize.Deserialize<Dictionary<string, object>>(response);
            result.Add(restObject);
            result.Add(restResponse);
            result.Add(intStatus);
            return result;
        }

        protected async Task<object> DeleteEmployee(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(RemoveEmployee, employeeId));
            var request = new RestRequest(resource, Method.DELETE);
            var response = RestClient.Execute(request);
            var status = response.StatusCode;
            var intStatus = Convert.ToInt32(status);
            RestResponse restResponse = (RestResponse)response;
            List<object> result = new List<object>();
            var deserialize = new RestSharp.Serialization.Json.JsonDeserializer();
            var restObject = deserialize.Deserialize<Dictionary<string, object>>(response);
            result.Add(restObject);
            result.Add(restResponse);
            result.Add(intStatus);
            return result;
        }
    }
}
