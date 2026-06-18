using HAsystem.Dents.Domain.Aggregates.DiagnosticoTratamientoAggregates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAsystem.Dents.Infrastructure.Persistence.Configurations;

public class DiagnosticoTratamientoConfiguration : IEntityTypeConfiguration<DiagnosticoTratamiento>
{
    public void Configure(EntityTypeBuilder<DiagnosticoTratamiento> builder)
    {
        builder.ToTable("diagnostico_tratamiento");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdDiagnostico");

        builder.Property(e => e.IdPaciente)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdPaciente");

        builder.Property(e => e.Fecha)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("fecha");

        builder.Property(e => e.Diagnostico)
               .IsRequired()
               .HasMaxLength(500)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("diagnostico");

        builder.Property(e => e.Tratamiento)
               .HasMaxLength(500)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("tratamiento");

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
