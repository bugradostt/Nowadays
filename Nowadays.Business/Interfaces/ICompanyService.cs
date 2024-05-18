using Nowadays.DataAccess.Dtos.Company;
using Nowadays.DataAccess.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.Business.Interfaces
{
    public interface ICompanyService
    {
        Task<ResponseDto<List<GetCompanyDto>>> GetCompanyAsync();
        Task<ResponseDto<NoDataDto>> AddCompanyAsync(AddCompanyDto company);
        Task<ResponseDto<NoDataDto>> UpdateCompanyAsync(UpdateCompanyDto company);
        Task<ResponseDto<NoDataDto>> DeleteCompanyAsync(string companyId);

    }
}
