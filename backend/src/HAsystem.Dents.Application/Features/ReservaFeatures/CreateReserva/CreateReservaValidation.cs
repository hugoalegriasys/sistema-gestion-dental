using FluentValidation;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;
public class CreateReservaValidation : AbstractValidator<ReservaCreateRequestDto>
{
    public CreateReservaValidation()
    {
        RuleFor(r => r.IdPaciente)
             .NotEmpty().WithMessage("El ID del paciente es obligatorio.")
             .GreaterThan(0).WithMessage("El ID del paciente debe ser mayor a 0.");

        RuleFor(r => r.EstadoReserva)
            .NotEmpty().WithMessage("El estado de la reserva es obligatorio.")
            .MaximumLength(50).WithMessage("El estado de la reserva no puede exceder los 50 caracteres.");

        RuleFor(r => r.FechaReserva)
            .NotEmpty().WithMessage("La fecha de reserva es obligatoria.")
            .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("La fecha de reserva debe estar en formato DD/MM/YYYY.");

        RuleFor(r => r.FechaAtencion)
            .NotEmpty().WithMessage("La fecha de atención es obligatoria.")
            .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("La fecha de atención debe estar en formato DD/MM/YYYY.");

        RuleFor(r => r.HoraAtencion)
            .NotEmpty().WithMessage("La hora de atención es obligatoria.")
            .Matches(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$").WithMessage("La hora de atención debe estar en formato HH:MM.");

        RuleFor(r => r.MotivoConsulta)
            .NotEmpty().WithMessage("El motivo de consulta es obligatorio.")
            .MaximumLength(200).WithMessage("El motivo de consulta no puede exceder los 200 caracteres.");

        RuleFor(r => r.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder los 500 caracteres.")
            .When(r => !string.IsNullOrEmpty(r.Observaciones));

        RuleFor(p => p.Dni)
            .NotEmpty().WithMessage("El DNI es obligatorio.")
            .Matches(@"^\d{8}$").WithMessage("El DNI debe tener 8 dígitos.");


    }

}