using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.UpdatePacientes;

public class UpdatePacienteValidation : AbstractValidator<PacienteUpdateRequestDto>
{
    public UpdatePacienteValidation()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

        RuleFor(p => p.Apellido)
            .NotEmpty().WithMessage("El apellido es obligatorio.")
            .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.");

        RuleFor(p => p.FechaNacimiento)
           .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
           .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("La fecha de nacimiento debe estar en formato DD/MM/YYYY.");

        RuleFor(p => p.TelefonoFijo)
            .MaximumLength(9).WithMessage("El teléfono fijo debe tener como máximo 9 dígitos.")
            .Matches(@"^\d{6,9}$").When(p => !string.IsNullOrEmpty(p.TelefonoFijo)).WithMessage("El teléfono fijo debe contener solo dígitos.");

        RuleFor(p => p.Direccion)
            .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres.");

        RuleFor(p => p.Dni)
            .Matches(@"^\d{8}$").When(p => !string.IsNullOrEmpty(p.Dni)).WithMessage("El DNI debe tener 8 dígitos.");

        RuleFor(p => p.Email)
            .EmailAddress().When(p => !string.IsNullOrEmpty(p.Email)).WithMessage("El email no tiene un formato válido.");

        RuleFor(p => p.FechaRegistro)
            .Matches(@"^\d{4}-\d{2}-\d{2}$").When(p => !string.IsNullOrEmpty(p.FechaRegistro))
            .WithMessage("La fecha de registro debe estar en formato YYYY-MM-DD.");

        RuleFor(p => p.LugarNacimiento)
            .MaximumLength(100).When(p => !string.IsNullOrEmpty(p.LugarNacimiento))
            .WithMessage("El lugar de nacimiento no puede exceder los 100 caracteres.");

        RuleFor(p => p.Ciudad)
            .MaximumLength(100).When(p => !string.IsNullOrEmpty(p.Ciudad))
            .WithMessage("La ciudad no puede exceder los 100 caracteres.");

        RuleFor(p => p.Celular)
            .Matches(@"^\d{9}$").When(p => !string.IsNullOrEmpty(p.Celular))
            .WithMessage("El número de celular debe tener 9 dígitos.");

        RuleFor(p => p.GradoInstruccion)
            .MaximumLength(50).When(p => !string.IsNullOrEmpty(p.GradoInstruccion))
            .WithMessage("El grado de instrucción no puede exceder los 50 caracteres.");

        RuleFor(p => p.Ocupacion)
            .MaximumLength(100).When(p => !string.IsNullOrEmpty(p.Ocupacion))
            .WithMessage("La ocupación no puede exceder los 100 caracteres.");

        RuleFor(p => p.Procedencia)
            .MaximumLength(100).When(p => !string.IsNullOrEmpty(p.Procedencia))
            .WithMessage("La procedencia no puede exceder los 100 caracteres.");

        RuleFor(p => p.AlergiaMedicamentos)
            .MaximumLength(200).When(p => !string.IsNullOrEmpty(p.AlergiaMedicamentos))
            .WithMessage("Las alergias a medicamentos no pueden exceder los 200 caracteres.");

        RuleFor(p => p.Apoderado)
            .MaximumLength(100).When(p => !string.IsNullOrEmpty(p.Apoderado))
            .WithMessage("El nombre del apoderado no puede exceder los 100 caracteres.");

        RuleFor(p => p.TelefonoApoderado)
            .Matches(@"^\d{9}$").When(p => !string.IsNullOrEmpty(p.TelefonoApoderado))
            .WithMessage("El teléfono del apoderado debe tener 9 dígitos.");

        RuleFor(p => p.Edad)
            .InclusiveBetween(0, 130).When(p => p.Edad.HasValue)
            .WithMessage("La edad debe estar entre 0 y 130.");
    }
}
