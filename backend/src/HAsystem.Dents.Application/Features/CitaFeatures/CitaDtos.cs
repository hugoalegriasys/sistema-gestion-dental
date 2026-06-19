namespace HAsystem.Dents.Application.Features.CitaFeatures;

public record CitaResponseDto(
    int IdCita,
    int IdReserva,
    int IdPaciente,
    string NombresPaciente,
    string ApellidosPaciente,
    string DniPaciente,
    DateTime FechaAtencion,
    TimeSpan HoraAtencion,
    string EstadoCita,
    string? Diagnostico,
    string? TratamientoRealizado,
    string? Observaciones,
    DateTime FechaRegistro
);

public record UpdateCitaRequestDto(
    int IdCita,
    string EstadoCita,
    string? Diagnostico,
    string? TratamientoRealizado,
    string? Observaciones
);
