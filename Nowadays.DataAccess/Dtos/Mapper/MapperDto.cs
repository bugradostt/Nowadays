using AutoMapper;
using Nowadays.DataAccess.Dtos.Company;
using Nowadays.DataAccess.Dtos.Employee;
using Nowadays.DataAccess.Dtos.Issue;
using Nowadays.DataAccess.Dtos.Project;
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

            CreateMap<GetProjectDto, ProjectEntity>().ReverseMap();
            CreateMap<AddProjectDto, ProjectEntity>().ReverseMap();

            CreateMap<GetEmployeeDto, EmployeeEntity>().ReverseMap();
            CreateMap<AddEmployeeDto, EmployeeEntity>().ReverseMap();

            CreateMap<GetIssueDto, IssueEntity>().ReverseMap();
            CreateMap<AddIssueDto, IssueEntity>().ReverseMap();

            CreateMap<AssignmentEmployeesToProjectDto , EmployeeProjectEntity>().ReverseMap();
            CreateMap<AssignmentIssueToProjectDto , IssueProjectEntity>().ReverseMap();
            CreateMap<AssignmentEmployeesToIssueDto , EmployeeIssueEntity>().ReverseMap();
        }
    }
}
