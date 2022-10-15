using Candidates.Application.Services.Interfaces;
using MediatR;

namespace Candidates.Application.Commands.Candidates
{
    public class UpdateCandidateCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

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
                
                candidate.Name = command.Name;
                candidate.Surname = command.Surname;
                candidate.Birthdate = command.Birthdate;    
                candidate.Email = command.Email;
                candidate.ModifyDate = DateTime.Now;

                await _candidateService.UpdateCandidate(candidate);

                return default;
            }
        }
    }
}