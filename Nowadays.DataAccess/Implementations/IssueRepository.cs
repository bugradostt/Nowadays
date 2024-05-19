using AutoMapper;
using Nowadays.DataAccess.Contexts;
using Nowadays.DataAccess.Interfaces;

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

    }
}