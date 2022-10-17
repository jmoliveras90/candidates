using Candidates.Application.Extensions;
using Candidates.Application.Services.Interfaces;
using MediatR;

namespace Candidates.Application.Commands.CandidateExperiences
{
    public class UpdateCandidateExperienceCommand : CandidateExperienceCommand, IRequest
    {
        public int Id { get; set; }

        public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateExperienceCommand>
        {
            private readonly ICandidateExperiencesService _candidateExperiencesService;

            public UpdateCandidateCommandHandler(ICandidateExperiencesService candidateExperiencesService)
            {
                _candidateExperiencesService = candidateExperiencesService;
            }

            public async Task<Unit> Handle(UpdateCandidateExperienceCommand command, CancellationToken cancellationToken)
            {
                var experience = await _candidateExperiencesService.GetCandidateExperience(command.Id);

                experience.Update(command);

                await _candidateExperiencesService.UpdateCandidateExperience(experience);

                return default;
            }
        }
    }
}