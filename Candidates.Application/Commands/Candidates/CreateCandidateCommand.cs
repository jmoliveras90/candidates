using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using MediatR;

namespace Candidates.Application.Commands.Candidates
{
    public class CreateCandidateCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

        public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand>
        {
            private readonly ICandidatesService _candidateService;

            public CreateCandidateCommandHandler(ICandidatesService candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<Unit> Handle(CreateCandidateCommand command, CancellationToken cancellationToken)
            {
                var candidate = new Candidate()
                {
                    Name = command.Name,
                    Surname = command.Surname,
                    Birthdate = command.Birthdate,
                    Email = command.Email,                    
                    InsertDate = DateTime.Now
                };

                await _candidateService.CreateCandidate(candidate);

                return default;
            }
        }
    }
}