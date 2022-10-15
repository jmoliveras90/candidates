using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces;

namespace Candidates.Application.Services
{
    public class CandidateExperiencesService : BaseService, ICandidateExperiencesService
    {
        private readonly IAsyncRepository<CandidateExperience> repository;

        public CandidateExperiencesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            repository = unitOfWork.AsyncRepository<CandidateExperience>();
        }

        public async Task<IEnumerable<CandidateExperience>> GetAllCandidateExperiences()
        {
            return await repository.GetAllAsync();
        }

        public async Task<CandidateExperience> GetCandidateExperience(int id)
        {
            return await repository.GetAsync(c => c.IdCandidate == id);
        }

        public async Task CreateCandidateExperience(CandidateExperience candidate)
        {
            await repository.AddAsync(candidate);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCandidateExperience(CandidateExperience candidate)
        {
            await repository.UpdateAsync(candidate);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCandidateExperience(CandidateExperience candidate)
        {
            await repository.DeleteAsync(candidate);
            await UnitOfWork.SaveChangesAsync();
        }      
    }
}
