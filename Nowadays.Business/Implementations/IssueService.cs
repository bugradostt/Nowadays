using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Interfaces;

namespace Nowadays.Business.Implementations
{
    public class IssueService : IIssueService
    {
        readonly IIssueRepository _ıssueRepository;
        public IssueService(IIssueRepository ıssueRepository)
        {
            _ıssueRepository = ıssueRepository;

        }
    }
}