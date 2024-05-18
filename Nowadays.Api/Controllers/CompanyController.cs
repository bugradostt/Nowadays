using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Company;

namespace Nowadays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : CustomBaseController
    {
        readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Route("get-company")]
        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            var result = await _companyService.GetCompanyAsync();
            return ActionResultInstance(result);

        }

        [Route("add-company")]
        [HttpPost]
        public async Task<IActionResult> AddCompany(AddCompanyDto company)
        {
            var result = await _companyService.AddCompanyAsync(company);
            return ActionResultInstance(result);

        }

        [Route("update-company")]
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyDto company)
        {
            var result = await _companyService.UpdateCompanyAsync(company);
            return ActionResultInstance(result);

        }

        [Route("delete-company")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(DeleteCompanyDto company)
        {
            var result = await _companyService.DeleteCompanyAsync(company.Id);
            return ActionResultInstance(result);

        }
    }
}
