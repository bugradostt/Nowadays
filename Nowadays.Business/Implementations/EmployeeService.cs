using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Employee;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Interfaces;

namespace Nowadays.Business.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        public async Task<ResponseDto<NoDataDto>> AddEmployeeAsync(AddEmployeeDto employee)
        {
            try
            {
                var response = await _employeeRepository.AddEmployeeAsync(employee);

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

        public async Task<ResponseDto<NoDataDto>> DeleteEmployeeAsync(string employeeId)
        {
            try
            {
                var response = await _employeeRepository.DeleteEmployeeAsync(employeeId);

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

        public async Task<ResponseDto<List<GetEmployeeDto>>> GetEmployeeAsync(string companyId)
        {
            try
            {
                var response = await _employeeRepository.GetEmployeeAsync(companyId);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<List<GetEmployeeDto>>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<List<GetEmployeeDto>>.Success(response.Data,200);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<GetEmployeeDto>>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> UpdateEmployeeAsync(UpdateEmployeeDto employee)
        {
            try
            {
                var response = await _employeeRepository.UpdateEmployeeAsync(employee);

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