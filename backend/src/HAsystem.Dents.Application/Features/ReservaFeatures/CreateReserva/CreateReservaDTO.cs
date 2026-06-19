namespace HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;
public record ReservaCreateRequestDto(
    int IdPaciente,
    string EstadoReserva,
    DateTime FechaReserva,
    DateTime FechaAtencion,
    TimeSpan HoraAtencion,
    string MotivoConsulta,
    string? Observaciones,
    string? Dni
    );

public record ReservaCreateResponseDTO(string dni, string mensaje);
