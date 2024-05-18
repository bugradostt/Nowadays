using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.DataAccess.Contexts;
using Nowadays.DataAccess.Dtos.Company;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Extensions;
using Nowadays.DataAccess.Interfaces;
using Nowadays.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.DataAccess.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly IMapper _mapper;
        readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<NoDataDto>> AddCompanyAsync(AddCompanyDto company)
        {
            try
            {
                // Aynı isme sahip başka bir veri var mı kontrolü
                bool isCompany = await _context.Companies.AnyAsync(x=>x.Name  == StringExtensions.Encrypt(company.Name));
                if (isCompany)
                {
                    return ResponseDto<NoDataDto>.Fail("There is already a company with this name!", 400, true);
                }

                var companyMapper = _mapper.Map<CompanyEntity>(company);
                companyMapper.CreatedAt = DateTime.Now;
                companyMapper.Invalidated = 1;
                companyMapper.Name = StringExtensions.Encrypt(company.Name);
                _context.Companies.Add(companyMapper);
                await _context.SaveChangesAsync();
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

                var companyList = await _context.Companies.ToListAsync();

               
                var mapperCompanyList = _mapper.Map<List<GetCompanyDto>>(companyList);


                foreach (var i in mapperCompanyList)
                {

                    i.Name = StringExtensions.Decrypt(i.Name);

                }
                return ResponseDto<List<GetCompanyDto>>.Success(mapperCompanyList, 200);
   

            }
            catch (Exception ex)
            {
                return ResponseDto<List<GetCompanyDto>>.Fail(ex.Message, 500, true);
            }
        }
    }
}
