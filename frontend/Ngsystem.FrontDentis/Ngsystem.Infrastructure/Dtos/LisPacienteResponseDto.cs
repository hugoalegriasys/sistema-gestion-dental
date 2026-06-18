using System.ComponentModel.DataAnnotations;

namespace Ngsystem.Infrastructure.Dtos;

public class LisPacienteResponseDto
{
    public int? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Dni { get; set; }
    public string? FechaNacimiento { get; set; }
    public string? TelefonoFijo { get; set; }
    public string? Email { get; set; }
    public string? LugarNacimiento { get; set; }
    public string? Ciudad { get; set; }
    public string? Direccion { get; set; }
    public string? Celular { get; set; }
    public string? GradoInstruccion { get; set; }
    public string? Ocupacion { get; set; }
    public string? Procedencia { get; set; }
    public string? AlergiaMedicamentos { get; set; }
    public string? Apoderado { get; set; }
    public string? TelefonoApoderado { get; set; }
    public int? Edad { get; set; }
    public string? Genero { get; set; }

}
public class ItemPacienteResponseDto
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Dni { get; set; }
    public string? FechaNacimiento { get; set; }
    public string? TelefonoFijo { get; set; }
    public string? Email { get; set; }
    public string? LugarNacimiento { get; set; }
    public string? Ciudad { get; set; }
    public string? Direccion { get; set; }
    public string? Celular { get; set; }
    public string? GradoInstruccion { get; set; }
    public string? Ocupacion { get; set; }
    public string? Procedencia { get; set; }
    public string? AlergiaMedicamentos { get; set; }
    public string? Apoderado { get; set; }
    public string? TelefonoApoderado { get; set; }
    public int? Edad { get; set; }
    public string? Genero { get; set; }

}