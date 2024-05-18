using Nowadays.DataAccess.Dtos.Company;
using Nowadays.DataAccess.Dtos.Response;

namespace Nowadays.DataAccess.Interfaces
{
    public interface ICompanyRepository
    {
        Task<ResponseDto<List<GetCompanyDto>>> GetCompanyAsync();
        Task<ResponseDto<NoDataDto>> AddCompanyAsync(AddCompanyDto company);
        Task<ResponseDto<NoDataDto>> UpdateCompanyAsync(UpdateCompanyDto company);
        Task<ResponseDto<NoDataDto>> DeleteCompanyAsync(string companyId);

    }
}
