using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;
public record PacienteCreateRequestDto(
    int? idPaciente,
    string? Nombre,
    string? Apellido,
    string FechaNacimiento,
    string? TelefonoFijo,
    string? Direccion,
    string? Dni,
    string? Email,
    string FechaRegistro,
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

public record PacienteCreateResponseDTO(string dni, string mensaje);