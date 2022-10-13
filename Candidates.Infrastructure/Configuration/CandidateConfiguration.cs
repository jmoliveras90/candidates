using Candidates.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Candidates.Infrastructure.Data.Configuration
{
    internal class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("candidates");
            builder.Property(c => c.IdCandidate).ValueGeneratedOnAdd();

            builder.HasKey(c => c.IdCandidate);
            builder.HasAlternateKey(c => c.Email);

            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Surname).HasMaxLength(150);
            builder.Property(c => c.Birthdate).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(250);
            builder.Property(c => c.InsertDate).IsRequired();
            builder.Property(c => c.ModifyDate).IsRequired(false);
        }
    }
}
