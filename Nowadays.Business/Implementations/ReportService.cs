using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Interfaces;

namespace Nowadays.Business.Implementations
{
    public class ReportService : IReportService
    {
        readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;

        }

    }
}