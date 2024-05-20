using Nowadays.DataAccess.Dtos.Issue;
using Nowadays.DataAccess.Dtos.Response;

namespace Nowadays.Business.Interfaces
{
    public interface IIssueService
    {
        Task<ResponseDto<List<GetIssueDto>>> GetIssueAsync(string projectId);
        Task<ResponseDto<NoDataDto>> AddIssueAsync(AddIssueDto issue);
        Task<ResponseDto<NoDataDto>> UpdateIssueAsync(UpdateIssueDto issue);
        Task<ResponseDto<NoDataDto>> DeleteIssueAsync(string issueId);

    }
}