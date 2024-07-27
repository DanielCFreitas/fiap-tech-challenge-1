using Microsoft.EntityFrameworkCore;
using TechChallenge.Infrastructure.Data;

namespace TechChallenge.Api.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TechChallengeDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("TechChallengeConnection");

                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine);
            });
        }
    }
}
