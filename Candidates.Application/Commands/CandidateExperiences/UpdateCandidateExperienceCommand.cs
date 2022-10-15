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

                experience.Salary = command.Salary;
                experience.Job = command.Job;
                experience.Description = command.Description;
                experience.IdCandidate = command.IdCandidate;
                experience.Company = command.Company;
                experience.BeginDate = command.BeginDate;
                experience.EndDate = command.EndDate;
                experience.ModifyDate = DateTime.Now;

                await _candidateExperiencesService.UpdateCandidateExperience(experience);

                return default;
            }
        }
    }
}