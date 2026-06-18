
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Infrastructure.Persistence.Configurations;
public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{

    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("paciente");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
              .ValueGeneratedOnAdd()
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .HasColumnName("IdPaciente");

        builder.Property(e => e.Nombre)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("nombre");

        builder.Property(e => e.Apellido)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("apellido");

        builder.Property(e => e.FechaNacimiento)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("fecha_nacimiento");

        builder.Property(e => e.TelefonoFijo)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasDefaultValue("")
               .HasColumnName("telefono_fijo");

        builder.Property(e => e.Direccion)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("direccion");

        builder.Property(e => e.Dni)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("dni");

        builder.Property(e => e.Email)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("email");

        builder.Property(e => e.FechaRegistro)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("fecha_registro");

        builder.Property(e => e.LugarNacimiento)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("lugar_nacimiento");

        builder.Property(e => e.Ciudad)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("ciudad");

        builder.Property(e => e.Celular)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("celular");

        builder.Property(e => e.GradoInstruccion)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("grado_instruccion");

        builder.Property(e => e.Ocupacion)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("ocupacion");

        builder.Property(e => e.Procedencia)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("procedencia");

        builder.Property(e => e.AlegiaMedicamentos)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("alergia_medicamentos");

        builder.Property(e => e.Apoderado)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("apoderado");

        builder.Property(e => e.TelefonoApoderado)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("telefono_apoderado");

        builder.Property(e => e.Edad)
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("edad");

        builder.Property(e => e.Activo)
             .IsRequired()
             .UsePropertyAccessMode(PropertyAccessMode.Field)
             .HasColumnName("activo");

        builder.HasMany(p => p.Reservas)
              .WithOne(r => r.Paciente)
              .HasForeignKey(r => r.IdPaciente)
              .OnDelete(DeleteBehavior.Restrict);
    }

}



