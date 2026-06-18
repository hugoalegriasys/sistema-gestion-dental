using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Domain.Aggregates.DiagnosticoTratamientoAggregates;
using HAsystem.Dents.Domain.Aggregates.HistorialClinicoAggregates;
using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;
using HAsystem.Dents.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Logging;

namespace HAsystem.Dents.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DentalContext>(options =>
        options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")
                 ).LogTo(Console.WriteLine, LogLevel.Information)
             );
        Console.WriteLine("========================================================");
        Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));
        Console.WriteLine("========================================================");
        services.AddScoped<IPacienteReadService, PacienteRepository>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IReservaReadService, ReservaRepository>();
        services.AddScoped<IReservaRepository, ReservaRepository>();
        services.AddScoped<IHistorialClinicoRepository, HistorialClinicoRepository>();
        services.AddScoped<IDiagnosticoTratamientoRepository, DiagnosticoTratamientoRepository>();
        services.AddScoped<IOdontogramaRepository, OdontogramaRepository>();

        return services;
    }
}
