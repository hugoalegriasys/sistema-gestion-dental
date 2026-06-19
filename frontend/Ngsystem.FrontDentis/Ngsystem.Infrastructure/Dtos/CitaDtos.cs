using Ngsystem.Infrastructure.Converters;
using System.Text.Json.Serialization;

namespace Ngsystem.Infrastructure.Dtos;

public class CitaResponseDto
{
    public int IdCita { get; set; }
    public int IdReserva { get; set; }
    public int IdPaciente { get; set; }
    public string? NombresPaciente { get; set; }
    public string? ApellidosPaciente { get; set; }
    public string? DniPaciente { get; set; }

    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime? FechaAtencion { get; set; }

    [JsonConverter(typeof(CustomTimeSpanConverter))]
    public TimeSpan? HoraAtencion { get; set; }

    public string? EstadoCita { get; set; }
    public string? Diagnostico { get; set; }
    public string? TratamientoRealizado { get; set; }
    public string? Observaciones { get; set; }
    public DateTime? FechaRegistro { get; set; }
}

public class UpdateCitaRequestDto
{
    public int IdCita { get; set; }
    public string? EstadoCita { get; set; }
    public string? Diagnostico { get; set; }
    public string? TratamientoRealizado { get; set; }
    public string? Observaciones { get; set; }
}
