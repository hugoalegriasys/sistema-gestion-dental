using HAsystem.Dents.Domain.Aggregates.CitaAggregates;
using HAsystem.Dents.Application.Features.CitaFeatures;

namespace HAsystem.Dents.Application.Features.CitaFeatures.UpdateCita;

public static class UpdateCitaMapping
{
    public static void ToUpdate(this Cita cita, UpdateCitaRequestDto request)
    {
        cita.Update(
            request.EstadoCita,
            request.Diagnostico,
            request.TratamientoRealizado,
            request.Observaciones
        );
    }
}
