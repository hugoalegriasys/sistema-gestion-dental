namespace HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;

public record ReservaUpdateRequestDto(
    int IdPaciente,
    string EstadoReserva,
    string FechaReserva,
    string FechaAtencion,
    string HoraAtencion,
    string MotivoConsulta,
    string? Observaciones,
    string Dni
    );
public record ReservaUpdateResponseDTO(string dni, string mensaje);