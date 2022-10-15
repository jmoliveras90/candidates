using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces.CandidateExperiences;
using System.Linq;

namespace Candidates.Infrastructure.Data.Repositories.CandidateExperiences
{
    public class CandidateExperienceRepository : RepositoryBase<CandidateExperience>, ICandidateExperienceRepository
    {
        public CandidateExperienceRepository(CandidatesContext context) : base(context)
        {       
        }       
    }   
}
