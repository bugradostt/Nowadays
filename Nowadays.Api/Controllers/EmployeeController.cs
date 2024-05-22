using Azure;
using KPSPublic;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Implementations;
using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Employee;
using Nowadays.DataAccess.Dtos.Partner;
using Nowadays.DataAccess.Dtos.Response;


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

            /* 
                Not : 
                Normalde Kimlik kontrolünü burda yapmamam gerekiyordu
                Servis kısmında KPSPublic.KPSPublicSoapClient değerine bir türlü 
                ulaşamadım vakit kaybetmek istemediğim için burda yapmak zorunda kaldım
            */
            if (string.IsNullOrEmpty(employee.TcIdentityNumber) ||
                employee.TcIdentityNumber.Length != 11 ||
                !employee.TcIdentityNumber.All(char.IsDigit))
            {
                return BadRequest("Tc Identity Number must be 11 characters and consist of numbers only!");
            }

            var client = new KPSPublic.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var responseMernis = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(employee.TcIdentityNumber), employee.Name, employee.Surname,employee.BirthYear);
            var resultMernis = responseMernis.Body.TCKimlikNoDogrulaResult;

            if (resultMernis == false)
            {
                return BadRequest("Information could not be verified...");
            }

            // Not 

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


            /* 
                Not : 
                Normalde Kimlik kontrolünü burda yapmamam gerekiyordu
                Servis kısmında KPSPublic.KPSPublicSoapClient değerine bir türlü 
                ulaşamadım vakit kaybetmek istemediğim için burda yapmak zorunda kaldım
            */

            if (string.IsNullOrEmpty(employee.TcIdentityNumber) ||
               employee.TcIdentityNumber.Length != 11 ||
               !employee.TcIdentityNumber.All(char.IsDigit))
            {
                return BadRequest("Tc Identity Number must be 11 characters and consist of numbers only!");
            }

            var client = new KPSPublic.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var responseMernis = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(employee.TcIdentityNumber), employee.Name, employee.Surname, employee.BirthYear);
            var resultMernis = responseMernis.Body.TCKimlikNoDogrulaResult;

            if (resultMernis == false)
            {
                return BadRequest("Information could not be verified...");
            }

            // Not

            var result = await _employeeService.UpdateEmployeeAsync(employee);
            return ActionResultInstance(result);

        }

    }
}