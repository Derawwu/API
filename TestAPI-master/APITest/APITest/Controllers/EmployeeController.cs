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

        protected async Task<object> GetEmployeeAsync()
        {
            var resource = string.Join(this.BaseUrl, GetEmployeeUrl);
            return await this.GetAsync(resource);
        }

        

        protected async Task<object> GetEmployeeByIdAsync(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(GetEmployeeByIdUrl, employeeId));
            return await this.GetAsync(resource);
        }

        protected async Task<object> CreateNewEmployeeAsync()
        {
            var resource = string.Join(this.BaseUrl, string.Format(CreateEmployee));
            return await this.PostAsync(resource);
        }

        protected async Task<object> CreateExistingEmployeeAsync(int idTest)
        {
            var resource = string.Join(this.BaseUrl, string.Format(CreateEmployee));
            return await this.PostExistingAsync(resource, idTest);
        }

        protected async Task<object> UpdataDataAboutEmployeeAsync(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(PutEmployee, employeeId));
            return await this.PutAsync(resource);
        }
        protected async Task<object> DeleteEmployeeAsync(int employeeId)
        {
            var resource = string.Join(this.BaseUrl, string.Format(RemoveEmployee, employeeId));
            return await this.DeleteAsync(resource);
        }
    }

}
