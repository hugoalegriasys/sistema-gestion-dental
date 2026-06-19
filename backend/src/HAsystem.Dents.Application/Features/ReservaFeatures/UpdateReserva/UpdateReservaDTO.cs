namespace HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;

public record ReservaUpdateRequestDto(
    int Id,
    int IdPaciente,
    string EstadoReserva,
    DateTime FechaReserva,
    DateTime FechaAtencion,
    TimeSpan HoraAtencion,
    string MotivoConsulta,
    string? Observaciones,
    string Dni
    );
public record ReservaUpdateResponseDTO(string dni, string mensaje);
