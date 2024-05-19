using AutoMapper;
using Nowadays.DataAccess.Contexts;
using Nowadays.DataAccess.Interfaces;

namespace Nowadays.DataAccess.Implementations
{
    public class ReportRepository : IReportRepository
    {
        readonly IMapper _mapper;
        readonly AppDbContext _context;
        public ReportRepository(AppDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

    }
}