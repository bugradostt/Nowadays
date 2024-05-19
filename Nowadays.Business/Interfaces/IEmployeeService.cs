using Nowadays.DataAccess.Dtos.Employee;
using Nowadays.DataAccess.Dtos.Response;

namespace Nowadays.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseDto<List<GetEmployeeDto>>> GetEmployeeAsync(string companyId);
        Task<ResponseDto<NoDataDto>> AddEmployeeAsync(AddEmployeeDto employee);
        Task<ResponseDto<NoDataDto>> UpdateEmployeeAsync(UpdateEmployeeDto employee);
        Task<ResponseDto<NoDataDto>> DeleteEmployeeAsync(string employeeId);
    }
}