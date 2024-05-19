using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Interfaces;

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

    }
}