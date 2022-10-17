using Candidates.Application.Commands.Candidates;
using Candidates.Domain.Entities;

namespace Candidates.Application.Extensions
{
    internal static class CandidateExtensions
    {
        /// <summary>
        /// Maps command into database entity class.
        /// </summary>
        /// <param name="command">The command object.</param>
        /// <returns>An instance of the database entity class object with values assigned from the command object.</returns>
        public static Candidate ToEntity(this CreateCandidateCommand command)
        {
            return new Candidate
            {
                Name = command.Name,
                Surname = command.Surname,
                Birthdate = command.Birthdate,
                Email = command.Email,
                InsertDate = DateTime.Now
            };
        }

        /// <summary>
        /// Updates the database entity class object with new values.
        /// </summary>
        /// <param name="entity">The current database entity class object.</param>
        /// <param name="command">The command object with updated values.</param>
        public static void Update(this Candidate entity, UpdateCandidateCommand command)
        {
            entity.Name = command.Name;
            entity.Surname = command.Surname;
            entity.Birthdate = command.Birthdate;
            entity.Email = command.Email;
            entity.ModifyDate = DateTime.Now;
        }
    }
}
