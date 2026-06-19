namespace HAsystem.Dents.Application.Features.ReservaFeatures;

public record ReservaResponseDto(
    int IdReserva,
    int IdPaciente,
    string NombresCompletos,
    string Dni,
    string Sexo,
    DateTime FechaNacimiento,
    string Celular,
    string Correo,
    string Direccion,
    string MotivoConsulta,
    string EstadoReserva,
    DateTime FechaReserva,
    DateTime FechaAtencion,
    TimeSpan HoraAtencion,
    string? Observaciones,
    DateTime FechaRegistro
);

public record SaveReservaRequestDto(
    int IdPaciente,
    DateTime FechaReserva,
    string EstadoReserva,
    string MotivoConsulta,
    DateTime FechaAtencion,
    TimeSpan HoraAtencion,
    string Dni,
    string? Observaciones
);

public record UpdateReservaRequestDto(
    int IdReserva,
    int IdPaciente,
    DateTime FechaReserva,
    string EstadoReserva,
    string MotivoConsulta,
    DateTime FechaAtencion,
    TimeSpan HoraAtencion,
    string Dni,
    string? Observaciones
);
