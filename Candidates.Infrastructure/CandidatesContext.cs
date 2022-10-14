using Candidates.Domain.Entities;
using Candidates.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure.Data
{
    public class CandidatesContext : DbContext
    {       
        public CandidatesContext(DbContextOptions<CandidatesContext> options) : base(options)
        {
        }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateExperience>()
             .HasOne(p => p.Candidate)
             .WithMany(b => b.CandidateExperiences)
             .HasForeignKey(c => c.IdCandidate);

            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateExperienceConfiguration());
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }
    }
}
