
using Microsoft.EntityFrameworkCore;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Common;
using HAsystem.Dents.Infrastructure.Persistence.Configurations;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Infrastructure.Persistence.Contexts;
public class DentalContext : DbContext, IUnitOfWork
{
    public DbSet<Paciente> Paciente { get; set; }
    public DbSet<Reserva> Reserva { get; set; }
    //public DbSet<Customer> Customers { get; set; }
    public DentalContext(DbContextOptions<DentalContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PacienteConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        //modelBuilder.ApplyConfiguration(new ComentaryConfiguration());
        //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}