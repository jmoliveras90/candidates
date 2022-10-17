using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces.Candidates;

namespace Candidates.Infrastructure.Data.Repositories.Candidates
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(CandidatesContext context) : base(context)
        {
        }        
    }   
}
