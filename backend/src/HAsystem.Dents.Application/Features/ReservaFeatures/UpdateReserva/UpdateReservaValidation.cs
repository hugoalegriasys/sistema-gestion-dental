using FluentValidation;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;

public class UpdateReservaValidation : AbstractValidator<ReservaUpdateRequestDto>
{
    public UpdateReservaValidation()
    {
        RuleFor(r => r.IdPaciente)
             .GreaterThanOrEqualTo(0).WithMessage("El ID del paciente no es válido.");

        RuleFor(r => r.EstadoReserva)
            .NotEmpty().WithMessage("El estado de la reserva es obligatorio.")
            .MaximumLength(50).WithMessage("El estado de la reserva no puede exceder los 50 caracteres.");

        RuleFor(r => r.FechaReserva)
            .NotEmpty().WithMessage("La fecha de reserva es obligatoria.");

        RuleFor(r => r.FechaAtencion)
            .NotEmpty().WithMessage("La fecha de atención es obligatoria.");

        RuleFor(r => r.HoraAtencion)
            .NotEmpty().WithMessage("La hora de atención es obligatoria.");

        RuleFor(r => r.MotivoConsulta)
            .NotEmpty().WithMessage("El motivo de consulta es obligatorio.")
            .MaximumLength(200).WithMessage("El motivo de consulta no puede exceder los 200 caracteres.");

        RuleFor(r => r.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder los 500 caracteres.")
            .When(r => !string.IsNullOrEmpty(r.Observaciones));
    }
}
