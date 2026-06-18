namespace HAsystem.Dents.Application.Features.PacienteFeatures.UpdatePacientes;

public record PacienteUpdateRequestDto(
    string? Nombre,
    string? Apellido,
    string FechaNacimiento,
    string? TelefonoFijo,
    string? Direccion,
    string? Dni,
    string? Email,
    string? FechaRegistro,
    string? LugarNacimiento,
    string? Ciudad,
    string? Celular,
    string? GradoInstruccion,
    string? Ocupacion,
    string? Procedencia,
    string? AlergiaMedicamentos,
    string? Apoderado,
    string? TelefonoApoderado,
    int? Edad
    );
public record PacienteUpdateResponseDTO(string dni, string mensaje);