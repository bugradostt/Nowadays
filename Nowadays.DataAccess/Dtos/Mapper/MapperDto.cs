using AutoMapper;
using Nowadays.DataAccess.Dtos.Company;
using Nowadays.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.DataAccess.Dtos.Mapper
{
    public class MapperDto : Profile
    {
        public MapperDto()
        {
            CreateMap<GetCompanyDto, CompanyEntity>().ReverseMap();
            CreateMap<AddCompanyDto, CompanyEntity>().ReverseMap();
        }
    }
}
