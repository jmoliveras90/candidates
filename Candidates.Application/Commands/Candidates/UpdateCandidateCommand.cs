using Candidates.Application.Extensions;
using Candidates.Application.Services.Interfaces;
using MediatR;

namespace Candidates.Application.Commands.Candidates
{
    public class UpdateCandidateCommand : CandidateCommand, IRequest
    {
        public int Id { get; set; }      

        public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand>
        {
            private readonly ICandidatesService _candidateService;

            public UpdateCandidateCommandHandler(ICandidatesService candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<Unit> Handle(UpdateCandidateCommand command, CancellationToken cancellationToken)
            {
                var candidate = await _candidateService.GetCandidate(command.Id);

                candidate.Update(command);

                await _candidateService.UpdateCandidate(candidate);

                return default;
            }
        }
    }
}