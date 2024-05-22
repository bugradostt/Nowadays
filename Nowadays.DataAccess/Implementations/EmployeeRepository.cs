using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.DataAccess.Contexts;
using Nowadays.DataAccess.Dtos.Employee;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Extensions;
using Nowadays.DataAccess.Interfaces;
using Nowadays.Entity.Entities;

namespace Nowadays.DataAccess.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly IMapper _mapper;
        readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<NoDataDto>> AddEmployeeAsync(AddEmployeeDto employee)
        {
            try
            {
                // TC kimlik numarası kontrolü
                if (string.IsNullOrEmpty(employee.TcIdentityNumber) || 
                employee.TcIdentityNumber.Length != 11 || 
                !employee.TcIdentityNumber.All(char.IsDigit))
                {
                    return ResponseDto<NoDataDto>.Fail("Tc Identity Number must be 11 characters and consist of numbers only!", 400, true);
                }

                // Şirket kontrolü
                bool isCompany = await _context.Companies
                .AnyAsync(x=>x.CompanyId ==employee.CompanyId);
                if (!isCompany)
                {
                    return ResponseDto<NoDataDto>.Fail("No such company found!", 400, true);
                }


                // Aynı isme sahip başka bir veri var mı kontrolü
                bool isEmployee = await _context.Employees
                .AnyAsync(x=>x.TcIdentityNumber  == StringExtensions.Encrypt(employee.TcIdentityNumber) && x.Invalidated ==1 && x.CompanyId ==employee.CompanyId);
                if (isEmployee)
                {
                    return ResponseDto<NoDataDto>.Fail("There is already a employee with this name!", 400, true);
                }

                var employeeMapper = _mapper.Map<EmployeeEntity>(employee);
                employeeMapper.CreatedAt = DateTime.Now;
                employeeMapper.Invalidated = 1;
                employeeMapper.Name = StringExtensions.Encrypt(employee.Name);
                employeeMapper.Surname = StringExtensions.Encrypt(employee.Surname);
                employeeMapper.TcIdentityNumber = StringExtensions.Encrypt(employee.TcIdentityNumber);
                _context.Employees.Add(employeeMapper);
                await _context.SaveChangesAsync();
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
                if (employeeId == null)
                {
                    return ResponseDto<NoDataDto>.Fail("Employee id cannot be empty!",400,true);
                }

                var foundEmployee = await _context.Employees
                .Where(x=>x.EmployeeId == employeeId)
                .FirstOrDefaultAsync();

                foundEmployee.Invalidated = 0;
                _context.Update(foundEmployee);
                await _context.SaveChangesAsync();

                return ResponseDto<NoDataDto>.Success(200);
                
            }
            catch (Exception ex )
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message,500,true);
            }
        }

        public async Task<ResponseDto<List<GetEmployeeDto>>> GetEmployeeAsync(string companyId)
        {
            try
            {

                var employeeList = await _context.Employees
                .Where(x=>x.Invalidated == 1 && x.CompanyId == companyId)
                .ToListAsync();

                var mapperEmployeeList = _mapper.Map<List<GetEmployeeDto>>(employeeList);


                foreach (var i in mapperEmployeeList)
                {

                    i.Name = StringExtensions.Decrypt(i.Name);
                    i.Surname = StringExtensions.Decrypt(i.Surname);
                    i.TcIdentityNumber = StringExtensions.MaskTCNumber(StringExtensions.Decrypt(i.TcIdentityNumber));

                }
                return ResponseDto<List<GetEmployeeDto>>.Success(mapperEmployeeList, 200);

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
                // TC kimlik numarası kontrolü
                if (string.IsNullOrEmpty(employee.TcIdentityNumber) || 
                employee.TcIdentityNumber.Length != 11 || 
                !employee.TcIdentityNumber.All(char.IsDigit))
                {
                    return ResponseDto<NoDataDto>.Fail("Tc Identity Number must be 11 characters and consist of numbers only!", 400, true);
                }

                // Aynı isme sahip başka bir veri var mı kontrolü
                bool isEmployee = await _context.Employees
                .AnyAsync(x=>x.TcIdentityNumber  == StringExtensions.Encrypt(employee.TcIdentityNumber) && x.Invalidated ==1);
                if (isEmployee)
                {
                    return ResponseDto<NoDataDto>.Fail("There is already a employee with this name!", 400, true);
                }

                var foundEmployee = await _context.Employees
                .Where(x=>x.EmployeeId == employee.EmployeeId)
                .FirstOrDefaultAsync();

                if (foundEmployee == null)
                {
                    return ResponseDto<NoDataDto>.Fail("Record not found.", 404, true);
                }

                foundEmployee.UpdatedAt = DateTime.Now;
                foundEmployee.Name = StringExtensions.Encrypt(employee.Name);
                foundEmployee.Surname = StringExtensions.Encrypt(employee.Surname);
                foundEmployee.TcIdentityNumber = StringExtensions.Encrypt(employee.TcIdentityNumber);
                _context.Employees.Update(foundEmployee);
                await _context.SaveChangesAsync();

                return ResponseDto<NoDataDto>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message,500,true); 
            }
        }

    }
}