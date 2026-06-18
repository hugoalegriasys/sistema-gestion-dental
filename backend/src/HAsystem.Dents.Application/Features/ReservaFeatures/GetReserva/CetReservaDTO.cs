public record ReservaRequestDto(string dni);
public record ReservaResponseDto(
    int IdPaciente,
    string EstadoReserva,
    string FechaReserva,
    string FechaAtencion,
    string HoraAtencion,
    string MotivoConsulta,
    string? Observaciones,
    string Dni
    );
