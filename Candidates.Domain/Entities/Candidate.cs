namespace Candidates.Domain.Entities
{
    public class Candidate : CandidateBase
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

        public IEnumerable<CandidateExperience> CandidateExperiences { get; set; }

        public Candidate()
        {
            CandidateExperiences = new List<CandidateExperience>();
        }
    }
}
