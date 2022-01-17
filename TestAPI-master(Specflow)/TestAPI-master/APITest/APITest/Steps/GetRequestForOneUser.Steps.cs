using APITest.Controllers;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace APITest.Steps
{

    [Binding]
    public sealed class GetRequestForOneUser : BaseController
    {
        public RestClient restClient = new RestClient("http://dummy.restapiexample.com/api/v1/");
        public RestRequest restRequest = new RestRequest();
        private const string GetEmployeeByIdUrl = "/employee/{0}";

        [Given(@"I perform GET operation for single employee ,where employeeId = (.*)")]
        public void GivenIPerformGETOperationForSingleEmployeeWhereEmployeeId(int id = 1)
        {
            var resource = string.Join(this.BaseUrl, string.Format(GetEmployeeByIdUrl, id));
            restRequest = new RestRequest(resource, Method.GET);
            var request = restClient.Execute(restRequest);
        }


        [Then(@"I should get response status ""(.*)""")]
        public void ThenIShouldGetResponseStatus(int status = 200)
        {
            var response = restClient.Execute(restRequest);
            var statusCode = response.StatusCode;
            var intStatus = Convert.ToInt32(statusCode);
            Assert.That(intStatus, Is.EqualTo(status));
        }
    }
}
