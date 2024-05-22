using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Implementations;
using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Employee;
using Nowadays.DataAccess.Dtos.Partner;


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


        [Route("get-employee")]
        [HttpPost]
        public async Task<IActionResult> GetEmployee(RequestCompanyIdDto request)
        {
            var result = await _employeeService.GetEmployeeAsync(request.CompanyId);
            return ActionResultInstance(result);

        }

        [Route("add-employee")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto employee)
        {
            var result = await _employeeService.AddEmployeeAsync(employee);
            return ActionResultInstance(result);

        }

        [Route("delete-employee")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(RequestEmployeeIdDto request)
        {
            var result = await _employeeService.DeleteEmployeeAsync(request.EmployeeId);
            return ActionResultInstance(result);
        }

        [Route("update-employee")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto employee)
        {
            var result = await _employeeService.UpdateEmployeeAsync(employee);
            return ActionResultInstance(result);

        }

    }
}