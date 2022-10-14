
using Candidates.Domain.Entities;

namespace Candidates.Application.Services.Interfaces
{
    public interface ICandidatesService
    {
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidate(int id);
        Task CreateCandidate(Candidate candidate);
        Task UpdateCandidate(Candidate candidate);
        Task DeleteCandidate(Candidate candidate);
    }
}
