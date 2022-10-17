using Candidates.Application.Extensions;
using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using MediatR;

namespace Candidates.Application.Commands.Candidates
{
    public class CreateCandidateCommand : CandidateCommand, IRequest
    {
        public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand>
        {
            private readonly ICandidatesService _candidateService;

            public CreateCandidateCommandHandler(ICandidatesService candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<Unit> Handle(CreateCandidateCommand command, CancellationToken cancellationToken)
            {               
                await _candidateService.CreateCandidate(command.ToEntity());

                return default;
            }
        }
    }
}