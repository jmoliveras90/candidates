using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using MediatR;

namespace Candidates.Application.Queries.CandidateExperiences
{
    public class GetCandidateExperienceQuery : IRequest<CandidateExperience>
    {
        public int Id { get; set; }

        public GetCandidateExperienceQuery(int id)
        {
            Id = id;
        }

        public class GetCandidateExperienceQueryHandler : IRequestHandler<GetCandidateExperienceQuery, CandidateExperience>
        {
            private readonly ICandidateExperiencesService _candidateExperiencesService;

            public GetCandidateExperienceQueryHandler(ICandidateExperiencesService candidatesService)
            {
                _candidateExperiencesService = candidatesService;
            }

            public async Task<CandidateExperience> Handle(GetCandidateExperienceQuery query, CancellationToken cancellationToken)
            {
                return await _candidateExperiencesService.GetCandidateExperience(query.Id);
            }
        }
    }
}
