public record PacienteRequestDto(string dni);
public record PacienteResponseDto(
    int? Id,
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
    string? AlegiaMedicamentos,
    string? Apoderado,
    string? TelefonoApoderado,
    int? Edad
    );
