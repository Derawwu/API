using APITest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowApi.Steps.DELETE
{
    [Binding]
    public sealed class DeleteResponseStatusSteps : EmployeeController
    {
        [When(@"I perform DELETE operation, where id = (.*)")]
        public async Task WhenIPerformDELETEOperationWhereId(int id)
        {
            Response = await this.DeleteEmployeeAsync(id);
            StatusCode = Convert.ToInt32(Response.StatusCode);
        }
    }
}
