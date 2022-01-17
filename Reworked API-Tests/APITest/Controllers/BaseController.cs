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
        protected RestClient RestClient => new RestClient(this.BaseUrl);

        protected async Task<object> Get(string resource)
        {
            var request =  new RestRequest(resource, Method.GET);
            var response = await RestClient.ExecuteAsync(request);
            return  response;
        }
        protected async Task<object> CreateNewEmployee(string resource)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(new { employee_name = "Eddie Murphy", employee_salary = 100500, employee_age = 88 });
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }

        protected async Task<RestResponse> CreateEmployeeById(string resource, int idTest)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(new { id = idTest, employee_name = "Eddie Murphy", employee_salary = 100500, employee_age = 88 });
            var response = await RestClient.ExecuteAsync(request);
            return (RestResponse)response;
        }

        protected async Task<RestResponse> UpdateEmployeeData(string resourse)
        {
            var request = new RestRequest(resourse, Method.PUT);
            request.AddJsonBody(new { id = 1, employee_name = "Frank Sinatra", employee_salary = 200500, employee_age = 188 });
            var response = await RestClient.ExecuteAsync(request);
            return (RestResponse)response;
        }

        protected async Task<RestResponse> DeleteEmployee(string resource)
        {
            var request = new RestRequest(resource, Method.DELETE);
            var response = await RestClient.ExecuteAsync(request);
            return (RestResponse)response;
        }
    }
}
