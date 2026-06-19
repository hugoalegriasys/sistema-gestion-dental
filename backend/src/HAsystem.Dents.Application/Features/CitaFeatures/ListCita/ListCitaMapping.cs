namespace HAsystem.Dents.Application.Features.CitaFeatures.ListCita;

public static class ListCitaMapping
{
    public static List<CitaResponseDto> ToListaCitaResponse(this IEnumerable<dynamic> results)
    {
        return results.Select(r => new CitaResponseDto(
            (int)r.IdCita,
            (int)r.IdReserva,
            (int)r.IdPaciente,
            (string)r.NombresPaciente,
            (string)r.ApellidosPaciente,
            (string)r.DniPaciente,
            (DateTime)r.FechaAtencion,
            (TimeSpan)r.HoraAtencion,
            (string)r.EstadoCita,
            r.Diagnostico as string,
            r.TratamientoRealizado as string,
            r.Observaciones as string,
            (DateTime)r.FechaRegistro
        )).ToList();
    }
}
