using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Data
{
    public class TechChallengeDbContext : DbContext
    {
        public TechChallengeDbContext(DbContextOptions<TechChallengeDbContext> options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechChallengeDbContext).Assembly);
        }
    }
}
