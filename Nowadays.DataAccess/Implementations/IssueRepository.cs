using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.DataAccess.Contexts;
using Nowadays.DataAccess.Dtos.Issue;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Extensions;
using Nowadays.DataAccess.Interfaces;
using Nowadays.Entity.Entities;

namespace Nowadays.DataAccess.Implementations
{
    public class IssueRepository : IIssueRepository
    {
        readonly IMapper _mapper;
        readonly AppDbContext _context;
        public IssueRepository(AppDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<NoDataDto>> AddIssueAsync(AddIssueDto issue)
        {
            
            try
            {
                // Proje kontrolü
                bool isProject = await _context.Projects
                .AnyAsync(x=>x.ProjectId ==issue.ProjectId);
                if (!isProject)
                {
                    return ResponseDto<NoDataDto>.Fail("No such project found!", 400, true);
                }

                var issueMapper = _mapper.Map<IssueEntity>(issue);
                issueMapper.CreatedAt = DateTime.Now;
                issueMapper.Invalidated = 1;
                issueMapper.Title = StringExtensions.Encrypt(issue.Title);
                issueMapper.Detail = StringExtensions.Encrypt(issue.Detail);
                _context.Issues.Add(issueMapper);
                await _context.SaveChangesAsync();
                return ResponseDto<NoDataDto>.Success(200);

            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        
        public async Task<ResponseDto<NoDataDto>> AssignmentEmployeesToIssueAsync(AssignmentEmployeesToIssueDto assignmentEmployeesToIssue)
        {

            try
            {
                 // Görec kontrolü
                bool isIssue = await _context.Issues
                .AnyAsync(x=>x.IssueId ==assignmentEmployeesToIssue.IssueId);
                if (!isIssue)
                {
                    return ResponseDto<NoDataDto>.Fail("No such issue found!", 400, true);
                }

                 // Çalışan kontrolü
                bool isEmployee = await _context.Employees
                .AnyAsync(x=>x.EmployeeId ==assignmentEmployeesToIssue.EmployeeId);
                if (!isEmployee)
                {
                    return ResponseDto<NoDataDto>.Fail("No such employee found!", 400, true);
                }

                // Çalışan Projede mi
                //Yapılacak


                var assignmentMapper = _mapper.Map<EmployeeIssueEntity>(assignmentEmployeesToIssue);
                _context.EmployeeIssues.Add(assignmentMapper);
                await _context.SaveChangesAsync();
                return ResponseDto<NoDataDto>.Success(200);

            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }


        public async Task<ResponseDto<NoDataDto>> DeleteIssueAsync(string issueId)
        {
            try
            {
                if (issueId == null)
                {
                    return ResponseDto<NoDataDto>.Fail("Issue id cannot be empty!",400,true);
                }

                var foundIssue = await _context.Issues
                .Where(x=>x.IssueId == issueId)
                .FirstOrDefaultAsync();

                foundIssue.Invalidated = 0;
                _context.Update(foundIssue);
                await _context.SaveChangesAsync();

                return ResponseDto<NoDataDto>.Success(200);
                
            }
            catch (Exception ex )
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message,500,true);
            }
        }

        public async Task<ResponseDto<List<GetIssueDto>>> GetIssueAsync(string projectId)
        {
            try
            {

                var issueList = await _context.Issues
                .Where(x=>x.Invalidated == 1 && x.ProjectId == projectId)
                .ToListAsync();

                var mapperIssueList = _mapper.Map<List<GetIssueDto>>(issueList);


                foreach (var i in mapperIssueList)
                {

                    i.Title = StringExtensions.Decrypt(i.Title);
                    i.Detail = StringExtensions.Decrypt(i.Detail);

                }
                return ResponseDto<List<GetIssueDto>>.Success(mapperIssueList, 200);

            }
            catch (Exception ex)
            {
                return ResponseDto<List<GetIssueDto>>.Fail(ex.Message, 500, true);
            }

        }

        public async Task<ResponseDto<NoDataDto>> UpdateIssueAsync(UpdateIssueDto issue)
        {
            try
            {


                var foundIssue  = await _context.Issues
                .Where(x=>x.IssueId == issue.IssueId)
                .FirstOrDefaultAsync();

                if (foundIssue == null)
                {
                    return ResponseDto<NoDataDto>.Fail("Record not found.", 404, true);
                }

                foundIssue.UpdatedAt = DateTime.Now;
                foundIssue.Title = StringExtensions.Encrypt(issue.Title);
                foundIssue.Detail = StringExtensions.Encrypt(issue.Detail);
                _context.Issues.Update(foundIssue);
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