
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Infrastructure.Persistence.Configurations;
public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{

    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("Reserva");

        builder.HasKey(e => e.IdPaciente);

        builder.Property(e => e.IdPaciente)
               .ValueGeneratedOnAdd()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdPaciente");

        builder.Property(e => e.EstadoReserva)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("EstadoReserva");

        builder.Property(e => e.FechaReserva)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("FechaReserva");

        builder.Property(e => e.FechaAtencion)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("FechaAtencion");

        builder.Property(e => e.HoraAtencion)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("HoraAtencion");

        builder.Property(e => e.MotivoConsulta)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("MotivoConsulta");

        builder.Property(e => e.Observaciones)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Observaciones");

        builder.Property(e => e.Dni)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Dni");
    }

}



