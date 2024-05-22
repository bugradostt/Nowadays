using Nowadays.DataAccess.Dtos.Issue;
using Nowadays.DataAccess.Dtos.Response;

namespace Nowadays.DataAccess.Interfaces
{
    public interface IIssueRepository
    {
        Task<ResponseDto<List<GetIssueDto>>> GetIssueAsync(string projectId);
        Task<ResponseDto<NoDataDto>> AddIssueAsync(AddIssueDto issue);
        Task<ResponseDto<NoDataDto>> UpdateIssueAsync(UpdateIssueDto issue);
        Task<ResponseDto<NoDataDto>> DeleteIssueAsync(string issueId);
        Task<ResponseDto<NoDataDto>> AssignmentEmployeesToIssueAsync(AssignmentEmployeesToIssueDto assignmentEmployeesToIssue);

    }
}