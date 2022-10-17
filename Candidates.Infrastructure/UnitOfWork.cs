using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces;
using Candidates.Domain.Interfaces.CandidateExperiences;
using Candidates.Domain.Interfaces.Candidates;
using Candidates.Infrastructure.Data.Repositories;
using Candidates.Infrastructure.Data.Repositories.CandidateExperiences;
using Candidates.Infrastructure.Data.Repositories.Candidates;

namespace Candidates.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CandidatesContext _dbContext;
        public ICandidateRepository Candidates { get; private set; }
        public ICandidateExperienceRepository CandidateExperiences { get; private set; }

        public UnitOfWork(CandidatesContext dbContext)
        {
            _dbContext = dbContext;
            Candidates = new CandidateRepository(_dbContext);
            CandidateExperiences = new CandidateExperienceRepository(_dbContext);
        }       

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
