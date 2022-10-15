using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using MediatR;

namespace Candidates.Application.Commands.CandidateExperiences
{
    public class CreateCandidateExperienceCommand : CandidateExperienceCommand, IRequest
    {      
        public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateExperienceCommand>
        {
            private readonly ICandidateExperiencesService _candidateExperiencesService;

            public CreateCandidateCommandHandler(ICandidateExperiencesService candidateExperiencesService)
            {
                _candidateExperiencesService = candidateExperiencesService;
            }

            public async Task<Unit> Handle(CreateCandidateExperienceCommand command, CancellationToken cancellationToken)
            {
                var experience = new CandidateExperience()
                {
                    IdCandidate = command.IdCandidate,
                    BeginDate = command.BeginDate,
                    EndDate = command.EndDate,
                    Company = command.Company,
                    Job = command.Job,
                    Description = command.Description,
                    Salary = command.Salary,
                    InsertDate = DateTime.Now
                };

                await _candidateExperiencesService.CreateCandidateExperience(experience);

                return default;
            }
        }
    }
}