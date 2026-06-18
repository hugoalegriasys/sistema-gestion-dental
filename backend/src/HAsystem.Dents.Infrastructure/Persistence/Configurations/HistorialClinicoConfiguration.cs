using HAsystem.Dents.Domain.Aggregates.HistorialClinicoAggregates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAsystem.Dents.Infrastructure.Persistence.Configurations;

public class HistorialClinicoConfiguration : IEntityTypeConfiguration<HistorialClinico>
{
    public void Configure(EntityTypeBuilder<HistorialClinico> builder)
    {
        builder.ToTable("historial_clinico");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdHistorialClinico");

        builder.Property(e => e.IdPaciente)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdPaciente");

        builder.Property(e => e.FechaRegistro)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("fecha_registro");

        builder.Property(e => e.Descripcion)
               .IsRequired()
               .HasMaxLength(500)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("descripcion");

        builder.Property(e => e.Observaciones)
               .HasMaxLength(1000)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("observaciones");

        builder.HasOne(e => e.Paciente)
               .WithMany()
               .HasForeignKey(e => e.IdPaciente)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
