using Nowadays.Business.Interfaces;
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

    }
}