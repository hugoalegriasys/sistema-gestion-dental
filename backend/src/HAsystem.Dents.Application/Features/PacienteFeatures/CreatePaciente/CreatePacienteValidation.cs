using FluentValidation;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;
public class CreatePacienteValidation : AbstractValidator<PacienteCreateRequestDto>
{
    public CreatePacienteValidation()
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
            .NotEmpty().WithMessage("El teléfono es obligatorio.")
            .Matches(@"^\d{9}$").WithMessage("El teléfono debe tener 9 dígitos.");

        RuleFor(p => p.Direccion)
            .NotEmpty().WithMessage("La dirección es obligatoria.")
            .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres.");

        RuleFor(p => p.Dni)
            .NotEmpty().WithMessage("El DNI es obligatorio.")
            .Matches(@"^\d{8}$").WithMessage("El DNI debe tener 8 dígitos.");

        // Nuevos atributos agregados con validaciones ejemplo:

        RuleFor(p => p.Email)
            .EmailAddress().WithMessage("El email no es válido.")
            .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.Email));

        //RuleFor(p => p.FechaRegistro)
        //    .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("La fecha de registro debe estar en formato DD/MM/YYYY.")
        //    .When(p => !string.IsNullOrEmpty(p.FechaRegistro));

        RuleFor(p => p.LugarNacimiento)
            .MaximumLength(100).WithMessage("El lugar de nacimiento no puede exceder los 100 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.LugarNacimiento));

        RuleFor(p => p.Ciudad)
            .MaximumLength(100).WithMessage("La ciudad no puede exceder los 100 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.Ciudad));

        RuleFor(p => p.Celular)
            .Matches(@"^\d{9}$").WithMessage("El celular debe tener 9 dígitos.")
            .When(p => !string.IsNullOrEmpty(p.Celular));

        RuleFor(p => p.GradoInstruccion)
            .MaximumLength(50).WithMessage("El grado de instrucción no puede exceder los 50 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.GradoInstruccion));

        RuleFor(p => p.Ocupacion)
            .MaximumLength(100).WithMessage("La ocupación no puede exceder los 100 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.Ocupacion));

        RuleFor(p => p.Procedencia)
            .MaximumLength(100).WithMessage("La procedencia no puede exceder los 100 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.Procedencia));

        RuleFor(p => p.AlergiaMedicamentos)
            .MaximumLength(200).WithMessage("La alergia a medicamentos no puede exceder los 200 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.AlergiaMedicamentos));

        RuleFor(p => p.Apoderado)
            .MaximumLength(100).WithMessage("El apoderado no puede exceder los 100 caracteres.")
            .When(p => !string.IsNullOrEmpty(p.Apoderado));

        RuleFor(p => p.TelefonoApoderado)
            .Matches(@"^\d{9}$").WithMessage("El teléfono del apoderado debe tener 9 dígitos.")
            .When(p => !string.IsNullOrEmpty(p.TelefonoApoderado));

        RuleFor(p => p.Edad)
            .NotNull().WithMessage("La edad es requerida.")
            .InclusiveBetween(0, 120).WithMessage("La edad debe estar entre 0 y 120.");
    }

}