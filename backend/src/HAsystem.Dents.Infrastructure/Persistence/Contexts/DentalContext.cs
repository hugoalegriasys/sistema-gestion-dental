
using HAsystem.Dents.Domain.Aggregates.DiagnosticoTratamientoAggregates;
using HAsystem.Dents.Domain.Aggregates.HistorialClinicoAggregates;
using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;
using HAsystem.Dents.Domain.Common;
using HAsystem.Dents.Infrastructure.Persistence.Configurations;

namespace HAsystem.Dents.Infrastructure.Persistence.Contexts;
public class DentalContext : DbContext, IUnitOfWork
{
    public DbSet<Paciente> Paciente { get; set; }
    public DbSet<Reserva> Reserva { get; set; }
    public DbSet<HistorialClinico> HistorialClinico { get; set; }
    public DbSet<DiagnosticoTratamiento> DiagnosticoTratamiento { get; set; }
    public DbSet<Odontograma> Odontograma { get; set; }

    public DentalContext(DbContextOptions<DentalContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PacienteConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        modelBuilder.ApplyConfiguration(new HistorialClinicoConfiguration());
        modelBuilder.ApplyConfiguration(new DiagnosticoTratamientoConfiguration());
        modelBuilder.ApplyConfiguration(new OdontogramaConfiguration());
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}