﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candidates.Domain.Entities
{
    public class CandidateExperience : CandidateBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidateExperience { get; set; }
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Candidate Candidate { get; set; }
    }
}
