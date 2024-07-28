using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.SharedKernel.Data;

namespace TechChallenge.Infrastructure.Data
{
    public class TechChallengeDbContext : DbContext, IUnitOfWork
    {
        public TechChallengeDbContext(DbContextOptions<TechChallengeDbContext> options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechChallengeDbContext).Assembly);
        }

        public async Task<bool> ConfirmarTransacao()
        {
            return await base.SaveChangesAsync() > 1;
        }
    }
}
