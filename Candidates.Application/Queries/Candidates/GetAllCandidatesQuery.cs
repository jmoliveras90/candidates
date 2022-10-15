using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using MediatR;

namespace Candidates.Application.Queries
{
    public class GetAllCandidatesQuery : IRequest<IEnumerable<Candidate>>
    {
        public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<Candidate>>
        {
            private readonly ICandidatesService _candidatesService;

            public GetAllCandidatesQueryHandler(ICandidatesService candidatesService)
            {
                _candidatesService = candidatesService;
            }

            public async Task<IEnumerable<Candidate>> Handle(GetAllCandidatesQuery query, CancellationToken cancellationToken)
            {
                var e= await _candidatesService.GetAllCandidates();
                return e;
            }
        }
    }
}
