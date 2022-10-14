using Candidates.Domain.Entities;

namespace Candidates.Domain.Interfaces.Candidates
{
    public interface ICandidateRepository : IAsyncRepository<Candidate>
    {
    }
}
