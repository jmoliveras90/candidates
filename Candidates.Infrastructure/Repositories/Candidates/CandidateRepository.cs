using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces;
using Candidates.Domain.Interfaces.Candidates;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure.Data.Repositories.Candidates
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(IUnitOfWork context) : base(context)
        {
        }

        public new async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return await _dbSet.Include(c => c.CandidateExperiences).ToListAsync();
        }
    }   
}
