using Candidates.Application.Commands.Base;
using Candidates.Application.Services.Interfaces;
using MediatR;

namespace Candidates.Application.Commands.Candidates
{
    public class DeleteCandidateCommand : DeleteCommand, IRequest
    {
        public DeleteCandidateCommand(int id) : base(id)
        {
        }

        public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand>
        {
            private readonly ICandidatesService _candidateService;

            public DeleteCandidateCommandHandler(ICandidatesService candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<Unit> Handle(DeleteCandidateCommand command, CancellationToken cancellationToken)
            {
                var candidate = await _candidateService.GetCandidate(command.Id);

                if (candidate == null)
                {
                    return default;
                }

                await _candidateService.DeleteCandidate(candidate);

                return default;
            }
        }
    }
}