namespace Candidates.Application.Commands.Candidates
{
    public abstract class CandidateCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
    }
}
