namespace Candidates.Domain.Entities
{
    public abstract class CandidateBase
    {
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
