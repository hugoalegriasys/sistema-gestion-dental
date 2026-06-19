
public record LisReservaResponseDto(
    int Id,
    int IdPaciente,
    string EstadoReserva,
    string FechaReserva,
    string FechaAtencion,
    string HoraAtencion,
    string MotivoConsulta,
    string? Observaciones,
    string Dni
    );
