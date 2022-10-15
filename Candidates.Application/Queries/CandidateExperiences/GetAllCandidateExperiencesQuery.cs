using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using MediatR;

namespace Candidates.Application.Queries.CandidateExperiences
{
    public class GetAllCandidateExperiencesQuery : IRequest<IEnumerable<CandidateExperience>>
    {
        public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidateExperiencesQuery, IEnumerable<CandidateExperience>>
        {
            private readonly ICandidateExperiencesService _candidateExperiencesService;

            public GetAllCandidatesQueryHandler(ICandidateExperiencesService candidateExperiencesService)
            {
                _candidateExperiencesService = candidateExperiencesService;
            }

            public async Task<IEnumerable<CandidateExperience>> Handle(GetAllCandidateExperiencesQuery query, CancellationToken cancellationToken)
            {
                return await _candidateExperiencesService.GetAllCandidateExperiences();
            }
        }
    }
}
