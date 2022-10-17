using Candidates.Application.Commands.CandidateExperiences;
using Candidates.Domain.Entities;

namespace Candidates.Application.Extensions
{
    internal static class CandidateExperienceExtensions
    {
        /// <summary>
        /// Maps command into database entity class.
        /// </summary>
        /// <param name="command">The command object.</param>
        /// <returns>An instance of the database entity class object with values assigned from the command object.</returns>
        public static CandidateExperience ToEntity(this CreateCandidateExperienceCommand command)
        {
            return new CandidateExperience
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
        }

        /// <summary>
        /// Updates the database entity class object with new values.
        /// </summary>
        /// <param name="entity">The current database entity class object.</param>
        /// <param name="command">The command object with updated values.</param>
        public static void Update(this CandidateExperience entity, UpdateCandidateExperienceCommand command)
        {
            entity.Salary = command.Salary;
            entity.Job = command.Job;
            entity.Description = command.Description;
            entity.IdCandidate = command.IdCandidate;
            entity.Company = command.Company;
            entity.BeginDate = command.BeginDate;
            entity.EndDate = command.EndDate;
            entity.ModifyDate = DateTime.Now;
        }      
    }
}
