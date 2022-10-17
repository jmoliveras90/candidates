using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces.CandidateExperiences;
using Candidates.Domain.Interfaces.Candidates;

namespace Candidates.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        ICandidateExperienceRepository CandidateExperiences { get; }
        Task<int> SaveChangesAsync();
        IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
    }
}
