using Candidates.Application.Commands.Base;
using Candidates.Application.Services.Interfaces;
using MediatR;

namespace Candidates.Application.Commands.CandidateExperiences
{
    public class DeleteCandidateExperienceCommand : DeleteCommand, IRequest
    {
        public DeleteCandidateExperienceCommand(int id) : base(id)
        {
        }

        public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateExperienceCommand>
        {
            private readonly ICandidateExperiencesService _candidateExperiencesService;

            public DeleteCandidateCommandHandler(ICandidateExperiencesService candidateExperiencesService)
            {
                _candidateExperiencesService = candidateExperiencesService;
            }

            public async Task<Unit> Handle(DeleteCandidateExperienceCommand command, CancellationToken cancellationToken)
            {
                var experience = await _candidateExperiencesService.GetCandidateExperience(command.Id);

                if (experience == null)
                {
                    return default;
                }

                await _candidateExperiencesService.DeleteCandidateExperience(experience);

                return default;
            }
        }
    }
}