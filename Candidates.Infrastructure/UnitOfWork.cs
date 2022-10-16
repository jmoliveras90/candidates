using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces;
using Candidates.Infrastructure.Data.Repositories;

namespace Candidates.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CandidatesContext _dbContext;

        public UnitOfWork(CandidatesContext dbContext)
        {
            _dbContext = dbContext;
        }       

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
