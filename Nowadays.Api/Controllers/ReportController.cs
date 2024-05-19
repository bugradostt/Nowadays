using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Interfaces;

namespace Nowadays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : CustomBaseController
    {

        readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;

        }

    }
}