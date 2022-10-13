using Candidates.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Candidates.Infrastructure.Data.Configuration
{
    internal class CandidateExperienceConfiguration : IEntityTypeConfiguration<CandidateExperience>
    {
        public void Configure(EntityTypeBuilder<CandidateExperience> builder)
        {
            builder.ToTable("candidateexperiences");

            builder.Property(c => c.IdCandidateExperience).ValueGeneratedOnAdd();

            builder.HasKey(c => c.IdCandidateExperience);

            builder.Property(c => c.Company).HasMaxLength(100);
            builder.Property(c => c.Job).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(4000);
            builder.Property(c => c.Salary).HasPrecision(8,2);
            builder.Property(c => c.BeginDate).IsRequired();
            builder.Property(c => c.InsertDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired(false);
            builder.Property(c => c.ModifyDate).IsRequired(false);
        }
    }
}
