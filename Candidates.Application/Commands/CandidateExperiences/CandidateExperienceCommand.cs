namespace Candidates.Application.Commands.CandidateExperiences
{
    public abstract class CandidateExperienceCommand
    {
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
