using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces;

namespace Candidates.Application.Services
{
    public class CandidatesService : BaseService, ICandidatesService
    {
        private readonly IAsyncRepository<Candidate> repository;

        public CandidatesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            repository = unitOfWork.AsyncRepository<Candidate>();
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            return await repository.GetAsync(c => c.IdCandidate == id);
        }

        public async Task CreateCandidate(Candidate candidate)
        {
            await repository.AddAsync(candidate);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCandidate(Candidate candidate)
        {
            await repository.UpdateAsync(candidate);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCandidate(Candidate candidate)
        {
            await repository.DeleteAsync(candidate);
            await UnitOfWork.SaveChangesAsync();
        }      
    }
}
