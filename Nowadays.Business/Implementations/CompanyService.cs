using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Company;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.Business.Implementations
{
    public class CompanyService : ICompanyService
    {
        readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ResponseDto<NoDataDto>> AddCompanyAsync(AddCompanyDto company)
        {
            try
            {
                var response = await _companyRepository.AddCompanyAsync(company);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<NoDataDto>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<NoDataDto>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> DeleteCompanyAsync(string companyId)
        {
            try
            {
                var response = await _companyRepository.DeleteCompanyAsync(companyId);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<NoDataDto>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<NoDataDto>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<List<GetCompanyDto>>> GetCompanyAsync()
        {
            try
            {
                var response = await _companyRepository.GetCompanyAsync();

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<List<GetCompanyDto>>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<List<GetCompanyDto>>.Success(response.Data, 200);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<GetCompanyDto>>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> UpdateCompanyAsync(UpdateCompanyDto company)
        {
            try
            {
                var response = await _companyRepository.UpdateCompanyAsync(company);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<NoDataDto>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<NoDataDto>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }
    }
}
