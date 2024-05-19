using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Interfaces;

namespace Nowadays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : CustomBaseController
    {
        readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }

    }
}