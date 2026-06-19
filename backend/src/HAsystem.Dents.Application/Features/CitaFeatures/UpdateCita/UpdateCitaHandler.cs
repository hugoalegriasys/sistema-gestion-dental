using FluentValidation;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.CitaAggregates;

namespace HAsystem.Dents.Application.Features.CitaFeatures.UpdateCita;

public class UpdateCitaHandler
{
    private readonly IValidator<UpdateCitaRequestDto> _validator;
    private readonly ICitaRepository _citaRepository;

    public UpdateCitaHandler(IValidator<UpdateCitaRequestDto> validator, ICitaRepository citaRepository)
    {
        _validator = validator;
        _citaRepository = citaRepository;
    }

    public async Task<Result<string>> Handle(UpdateCitaRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new CustomErrorCode(string.Empty, e.ErrorMessage, "Validacion"))
                .ToList();
            return Result<string>.Failure(null, errors);
        }

        var cita = await _citaRepository.GetByIdAsync(request.IdCita);
        if (cita == null)
            return Result<string>.Failure(new CustomErrorCode(string.Empty, "Cita no encontrada", "Validacion"));

        cita.Update(
            request.EstadoCita,
            request.Diagnostico,
            request.TratamientoRealizado,
            request.Observaciones
        );

        _citaRepository.Update(cita);
        await _citaRepository.UnitOfWork.SaveAsync();

        return Result<string>.Success("Cita actualizada exitosamente");
    }
}
