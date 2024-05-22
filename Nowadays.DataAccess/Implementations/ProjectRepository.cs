using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.DataAccess.Contexts;
using Nowadays.DataAccess.Dtos.Project;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Extensions;
using Nowadays.DataAccess.Interfaces;
using Nowadays.Entity.Entities;

namespace Nowadays.DataAccess.Implementations
{
    public class ProjectRepository :IProjectRepository
    {
        readonly IMapper _mapper;
        readonly AppDbContext _context;

        public ProjectRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponseDto<NoDataDto>> AddProjectAsync(AddProjectDto project)
        {
            try
            {
                // Şirket kontrolü
                bool isCompany = await _context.Companies
                .AnyAsync(x=>x.CompanyId ==project.CompanyId);
                if (!isCompany)
                {
                    return ResponseDto<NoDataDto>.Fail("No such company found!", 400, true);
                }


                // Aynı isme sahip başka bir veri var mı kontrolü
                bool isProject = await _context.Projects
                .AnyAsync(x=>x.Name  == StringExtensions.Encrypt(project.Name) && x.Invalidated ==1 && x.CompanyId ==project.CompanyId);
                if (isProject)
                {
                    return ResponseDto<NoDataDto>.Fail("There is already a project with this name!", 400, true);
                }

                var projectMapper = _mapper.Map<ProjectEntity>(project);
                projectMapper.CreatedAt = DateTime.Now;
                projectMapper.Invalidated = 1;
                projectMapper.Name = StringExtensions.Encrypt(project.Name);
                _context.Projects.Add(projectMapper);
                await _context.SaveChangesAsync();
                return ResponseDto<NoDataDto>.Success(200);

            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> AssignmentEmployeesToProjectAsync(AssignmentEmployeesToProjectDto assignmentEmployeesToProject)
        {

            try
            {
                 // Proje kontrolü
                bool isProject = await _context.Projects
                .AnyAsync(x=>x.ProjectId ==assignmentEmployeesToProject.ProjectId);
                if (!isProject)
                {
                    return ResponseDto<NoDataDto>.Fail("No such project found!", 400, true);
                }

                 // Çalışan kontrolü
                bool isEmployee = await _context.Employees
                .AnyAsync(x=>x.EmployeeId ==assignmentEmployeesToProject.EmployeeId);
                if (!isEmployee)
                {
                    return ResponseDto<NoDataDto>.Fail("No such employee found!", 400, true);
                }


                var assignmentMapper = _mapper.Map<EmployeeProjectEntity>(assignmentEmployeesToProject);
                _context.EmployeeProjects.Add(assignmentMapper);
                await _context.SaveChangesAsync();
                return ResponseDto<NoDataDto>.Success(200);

            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }


    public async Task<ResponseDto<NoDataDto>> AssignmentIssueToProjectAsync(AssignmentIssueToProjectDto assignmentIssueToProject)
        {

            try
            {
                 // Proje kontrolü
                bool isProject = await _context.Projects
                .AnyAsync(x=>x.ProjectId ==assignmentIssueToProject.ProjectId);
                if (!isProject)
                {
                    return ResponseDto<NoDataDto>.Fail("No such project found!", 400, true);
                }

                 // Görev kontrolü
                bool isIssue = await _context.Issues
                .AnyAsync(x=>x.IssueId ==assignmentIssueToProject.IssueId);
                if (!isIssue)
                {
                    return ResponseDto<NoDataDto>.Fail("No such issue found!", 400, true);
                }


                var assignmentMapper = _mapper.Map<IssueProjectEntity>(assignmentIssueToProject);
                _context.IssueProjects.Add(assignmentMapper);
                await _context.SaveChangesAsync();
                return ResponseDto<NoDataDto>.Success(200);

            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }


        public async Task<ResponseDto<NoDataDto>> DeleteProjectAsync(string projectId)
        {
            try
            {
                if (projectId == null)
                {
                    return ResponseDto<NoDataDto>.Fail("Project id cannot be empty!",400,true);
                }

                var foundProject = await _context.Projects
                .Where(x=>x.ProjectId == projectId)
                .FirstOrDefaultAsync();

                foundProject.Invalidated = 0;
                _context.Update(foundProject);
                await _context.SaveChangesAsync();

                return ResponseDto<NoDataDto>.Success(200);
                
            }
            catch (Exception ex )
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message,500,true);
            }
        }

        public async Task<ResponseDto<List<GetProjectDto>>> GetProjectAsync(string companyId)
        {
            try
            {

                var projectList = await _context.Projects
                .Where(x=>x.Invalidated == 1 && x.CompanyId == companyId)
                .ToListAsync();

                var mapperProjectList = _mapper.Map<List<GetProjectDto>>(projectList);


                foreach (var i in mapperProjectList)
                {

                    i.Name = StringExtensions.Decrypt(i.Name);

                }
                return ResponseDto<List<GetProjectDto>>.Success(mapperProjectList, 200);
   

            }
            catch (Exception ex)
            {
                return ResponseDto<List<GetProjectDto>>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> UpdateProjectAsync(UpdateProjectDto project)
        {
            try
            {
                // Şirket kontrolü
                bool isCompany = await _context.Companies
                .AnyAsync(x=>x.CompanyId ==project.CompanyId);
                if (!isCompany)
                {
                    return ResponseDto<NoDataDto>.Fail("No such company found!", 400, true);
                }


                // Aynı isme sahip başka bir veri var mı kontrolü
                bool isProject = await _context.Projects
                .AnyAsync(x=>x.Name  == StringExtensions.Encrypt(project.Name) && x.Invalidated ==1 && x.CompanyId ==project.CompanyId);
                if (isProject)
                {
                    return ResponseDto<NoDataDto>.Fail("There is already a project with this name!", 400, true);
                }

                var foundProject  = await _context.Projects
                .Where(x=>x.ProjectId == project.ProjectId)
                .FirstOrDefaultAsync();

                if (foundProject == null)
                {
                    return ResponseDto<NoDataDto>.Fail("Record not found.", 404, true);
                }

                foundProject.UpdatedAt = DateTime.Now;
                foundProject.Name = StringExtensions.Encrypt(project.Name);
                _context.Projects.Update(foundProject);
                await _context.SaveChangesAsync();

                return ResponseDto<NoDataDto>.Success(200);
            
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }
    }
}