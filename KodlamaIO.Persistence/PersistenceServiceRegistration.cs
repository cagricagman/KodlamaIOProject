using KodlamaIO.Application.Services.Repositories;
using KodlamaIO.Persistence.Context;
using KodlamaIO.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KodlamaIO.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("KodlamaIOConnectionString")));
        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        return services;
    }
}