using Nowadays.DataAccess.Dtos.Company;
using Nowadays.DataAccess.Dtos.Response;

namespace Nowadays.DataAccess.Interfaces
{
    public interface ICompanyRepository
    {
        Task<ResponseDto<List<GetCompanyDto>>> GetCompanyAsync();
        Task<ResponseDto<NoDataDto>> AddCompanyAsync(AddCompanyDto company);

    }
}
