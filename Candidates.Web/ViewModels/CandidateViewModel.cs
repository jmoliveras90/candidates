using Microsoft.AspNetCore.Mvc;

namespace Candidates.Web.ViewModels
{
    public class CandidateViewModel
    {
        public int? IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        [Remote(action: "VerifyEmail", controller: "Candidates", AdditionalFields = nameof(Email) + "," + nameof(IdCandidate))]
        public string Email { get; set; }
    }
}
