using HAsystem.Dents.Domain.Aggregates.CitaAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAsystem.Dents.Infrastructure.Persistence.Configurations;

public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("Cita");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdCita");

        builder.Property(e => e.IdReserva)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdReserva");

        builder.Property(e => e.IdPaciente)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdPaciente");

        builder.Property(e => e.FechaAtencion)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("FechaAtencion");

        builder.Property(e => e.HoraAtencion)
               .HasColumnType("time")
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("HoraAtencion");

        builder.Property(e => e.EstadoCita)
               .IsRequired()
               .HasMaxLength(50)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("EstadoCita");

        builder.Property(e => e.Diagnostico)
               .HasMaxLength(500)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Diagnostico");

        builder.Property(e => e.TratamientoRealizado)
               .HasMaxLength(500)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("TratamientoRealizado");

        builder.Property(e => e.Observaciones)
               .HasMaxLength(1000)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Observaciones");

        builder.Property(e => e.FechaRegistro)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("FechaRegistro");

        builder.HasOne(e => e.Paciente)
               .WithMany()
               .HasForeignKey(e => e.IdPaciente)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Reserva)
               .WithMany()
               .HasForeignKey(e => e.IdReserva)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
