using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAsystem.Dents.Infrastructure.Persistence.Configurations;

public class OdontogramaConfiguration : IEntityTypeConfiguration<Odontograma>
{
    public void Configure(EntityTypeBuilder<Odontograma> builder)
    {
        // Forzamos el nombre de la tabla
        builder.ToTable("Odontograma");

        // Mapeo de la Llave Primaria
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("IdOdontograma");

        // Mapeo expl�cito de cada columna al nombre real en SQL Server
        builder.Property(x => x.IdPaciente).HasColumnName("IdPaciente");
        builder.Property(x => x.NumeroDiente).HasColumnName("numero_diente");
        builder.Property(x => x.Observaciones).HasColumnName("observaciones");

        // Relaci�n expl�cita: evita que EF Core genere shadow property "PacienteId"
        builder.HasOne(e => e.Paciente)
               .WithMany()
               .HasForeignKey(e => e.IdPaciente)
               .OnDelete(DeleteBehavior.Restrict);

        // LOS DOS CULPABLES DEL ERROR 500:
        builder.Property(x => x.EstadoDiente).HasColumnName("estado");
        builder.Property(x => x.Fecha).HasColumnName("fecha_registro");
    }
}