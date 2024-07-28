using TechChallenge.Api.Services;
using TechChallenge.Api.Services.Interfaces;
using TechChallenge.Domain.Repository;
using TechChallenge.Infrastructure.Data.Repository;

namespace TechChallenge.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IContatoRepository, ContatoRepository>();

            // Services
            services.AddScoped<IContatoServices, ContatoServices>();
        }
    }
}
