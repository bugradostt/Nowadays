using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Issue;
using Nowadays.DataAccess.Dtos.Partner;

namespace Nowadays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : CustomBaseController
    {

        readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [Route("get-issue")]
        [HttpPost]
        public async Task<IActionResult> GetIssue(RequestProjectIdDto request)
        {
            var result = await _issueService.GetIssueAsync(request.ProjectId);
            return ActionResultInstance(result);
        }

        [Route("add-issue")]
        [HttpPost]
        public async Task<IActionResult> AddIssue(AddIssueDto issue)
        {
            var result = await _issueService.AddIssueAsync(issue);
            return ActionResultInstance(result);
        }

        [Route("update-issue")]
        [HttpPut]
        public async Task<IActionResult> UpdateIssue(UpdateIssueDto issue)
        {
            var result = await _issueService.UpdateIssueAsync(issue);
            return ActionResultInstance(result);
        }

        [Route("delete-issue")]
        [HttpDelete]
        public async Task<IActionResult> DeleteIssue(RequestIssueIdDto request )
        {
            var result = await _issueService.DeleteIssueAsync(request.IssueId);
            return ActionResultInstance(result);
        }

    }
}