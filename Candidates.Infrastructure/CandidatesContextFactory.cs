using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Candidates.Infrastructure.Data
{
    public class CandidatesContextFactory : IDesignTimeDbContextFactory<CandidatesContext>
    {
        public CandidatesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CandidatesContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=candidates;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CandidatesContext(optionsBuilder.Options);
        }
    }
}
