using APITest.Constants;
using APITest.Managers;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITest.Controllers
{
    public class BaseController : ConfigManager
    {
        protected string BaseUrl => Config[ConfigConstants.BaseUrl];
        protected RestClient RestClient => new(this.BaseUrl);

        protected async Task<object> Get(string resource)
        {
            var request = new RestRequest(resource, Method.Get);
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }
        protected async Task<object> CreateNewEmployee(string resource)
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(new { employee_name = "Eddie Murphy", employee_salary = 100500, employee_age = 88 });
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }

        protected async Task<RestResponse> CreateEmployeeById(string resource, int idTest)
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(new { id = idTest, employee_name = "Eddie Murphy", employee_salary = 100500, employee_age = 88 });
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }

        protected async Task<RestResponse> UpdateEmployeeData(string resourse, int id)
        {
            var request = new RestRequest(resourse, Method.Put);
            request.AddJsonBody(new { id = id, employee_name = "Frank Sinatra", employee_salary = 200500, employee_age = 188 });
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }

        protected async Task<RestResponse> DeleteEmployee(string resource)
        {
            var request = new RestRequest(resource, Method.Delete);
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }
    }
}
