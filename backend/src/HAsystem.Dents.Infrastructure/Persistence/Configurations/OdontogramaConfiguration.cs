using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAsystem.Dents.Infrastructure.Persistence.Configurations;

public class OdontogramaConfiguration : IEntityTypeConfiguration<Odontograma>
{
    public void Configure(EntityTypeBuilder<Odontograma> builder)
    {
        builder.ToTable("Odontograma");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdOdontograma");

        builder.Property(e => e.IdPaciente)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IdPaciente");

        builder.Property(e => e.Fecha)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("fecha");

        builder.Property(e => e.NumeroDiente)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("numero_diente");

        builder.Property(e => e.EstadoDiente)
               .IsRequired()
               .HasMaxLength(50)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("estado_diente");

        builder.Property(e => e.Observaciones)
               .HasMaxLength(500)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("observaciones");

        builder.HasOne(e => e.Paciente)
               .WithMany()
               .HasForeignKey(e => e.IdPaciente)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
