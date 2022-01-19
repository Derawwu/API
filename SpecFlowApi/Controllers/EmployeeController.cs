using RestSharp;
using System.Threading.Tasks;

namespace APITest.Controllers
{
    public class EmployeeController : BaseController
    {
        private const string GetEmployeeUrl = "/employees";
        private const string GetEmployeeByIdUrl = "/employee/{0}";
        private const string CreateEmployee = "/create";
        private const string PutEmployee = "/update/{0}";
        private const string RemoveEmployee = "/delete/{0}";
        protected static int StatusCode { get; set; }
        protected static RestResponse? Response { get; set; }

        protected async Task<RestResponse> GetEmployeeAsync()
        {
            var resource = string.Join(this.BaseUrl, GetEmployeeUrl);
            return (RestResponse)await this.Get(resource);
        }

        protected async Task<RestResponse> GetEmployeeByIdAsync(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(GetEmployeeByIdUrl, employeeId));
            return (RestResponse)await this.Get(resource);
        }

        protected async Task<RestResponse> CreateNewEmployeeAsync()
        {
            var resource = string.Join(this.BaseUrl, string.Format(CreateEmployee));
            return (RestResponse)await this.CreateNewEmployee(resource);
        }

        protected async Task<RestResponse> CreateExistingEmployeeAsync(int idTest)
        {
            var resource = string.Join(this.BaseUrl, string.Format(CreateEmployee));
            return await this.CreateEmployeeById(resource, idTest);
        }

        protected async Task<RestResponse> UpdateDataAboutEmployeeAsync(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(PutEmployee, employeeId));
            return (RestResponse)await this.UpdateEmployeeData(resource, employeeId);
        }
        protected async Task<RestResponse> DeleteEmployeeAsync(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(RemoveEmployee, employeeId));
            return await this.DeleteEmployee(resource);
        }
    }
}
