
using Candidates.Domain.Entities;

namespace Candidates.Application.Services.Interfaces
{
    public interface ICandidateExperiencesService
    {
        Task<IEnumerable<CandidateExperience>> GetAllCandidateExperiences();
        Task<CandidateExperience> GetCandidateExperience(int id);
        Task CreateCandidateExperience(CandidateExperience experience);
        Task UpdateCandidateExperience(CandidateExperience experience);
        Task DeleteCandidateExperience(CandidateExperience experience);
    }
}
