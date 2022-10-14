namespace Candidates.Domain.Entities
{
    public abstract class CandidateBase : BaseEntity
    {
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
