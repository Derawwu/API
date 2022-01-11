using APITest.Constants;
using APITest.Managers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITest.Controllers
{
    public class BaseController : ConfigManager
    {
        protected string BaseUrl => Config[ConfigConstants.BaseUrl];
        protected RestClient RestClient => new RestClient(this.BaseUrl);

        protected async Task<object> GetAsync(string resource)
        {
            var request = new RestRequest(resource, Method.GET);

            return await this.RestClient.GetAsync<object>(request);
        }

        protected async Task<object> PostAsync(string resource)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(new { name = "Eddie Murphy", employee_salary = 100500, employee_age = 88 });
            return await RestClient.PostAsync<object>(request);
        }

        protected async Task<object> PostExistingAsync(string resource, int idTest)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(new { id = idTest, employee_name = "Eddie Murphy", employee_salary = 100500, employee_age = 88 }); 
            return await RestClient.PostAsync<object>(request);
        }

        protected async Task<object> PutAsync(string resourse)
        {
            var request = new RestRequest(resourse, Method.PUT);
            request.AddJsonBody(new { id =1 , employee_name = "Frank Sinatra", employee_salary = 200500, employee_age = 188 });
            return await RestClient.PutAsync<object>(request);
        }

        protected async Task<object> DeleteAsync(string resource)
        {
            var request = new RestRequest(resource, Method.DELETE);

            return await this.RestClient.DeleteAsync<object>(request);
        }
    }
}
