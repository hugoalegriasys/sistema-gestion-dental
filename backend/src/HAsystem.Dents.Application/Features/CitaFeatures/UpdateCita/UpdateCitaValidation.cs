using HAsystem.Dents.Application.Features.CitaFeatures;
using FluentValidation;

namespace HAsystem.Dents.Application.Features.CitaFeatures.UpdateCita;

public class UpdateCitaValidator : AbstractValidator<UpdateCitaRequestDto>
{
    public UpdateCitaValidator()
    {
        RuleFor(x => x.IdCita)
            .GreaterThan(0).WithMessage("IdCita es requerido");

        RuleFor(x => x.EstadoCita)
            .NotEmpty().WithMessage("EstadoCita es requerido")
            .MaximumLength(50);

        When(x => x.EstadoCita == "Atendida", () =>
        {
            RuleFor(x => x.Diagnostico)
                .NotEmpty().WithMessage("Diagnóstico es requerido cuando la cita es Atendida");
            RuleFor(x => x.TratamientoRealizado)
                .NotEmpty().WithMessage("TratamientoRealizado es requerido cuando la cita es Atendida");
        });
    }
}
