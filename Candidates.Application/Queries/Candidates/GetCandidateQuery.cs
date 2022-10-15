using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using MediatR;

namespace Candidates.Application.Queries.Candidates
{
    public class GetCandidateQuery : IRequest<Candidate>
    {
        public int Id { get; set; }

        public GetCandidateQuery(int id)
        {
            Id = id;
        }

        public class GetCandidateQueryHandler : IRequestHandler<GetCandidateQuery, Candidate>
        {
            private readonly ICandidatesService _candidatesService;

            public GetCandidateQueryHandler(ICandidatesService candidatesService)
            {
                _candidatesService = candidatesService;
            }

            public async Task<Candidate> Handle(GetCandidateQuery query, CancellationToken cancellationToken)
            {
                return await _candidatesService.GetCandidate(query.Id);
            }
        }
    }
}
