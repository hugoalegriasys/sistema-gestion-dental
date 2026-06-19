using Ngsystem.Infrastructure.Converters;
using System.Text.Json.Serialization;

namespace Ngsystem.Infrastructure.Dtos;

public class SaveReservaRequestDto
{
    public int Id { get; set; }
    public int IdPaciente { get; set; }
    public string EstadoReserva { get; set; } = string.Empty;
    public DateTime? FechaReserva { get; set; }
    public DateTime? FechaAtencion { get; set; }
    public TimeSpan? HoraAtencion { get; set; }
    public string MotivoConsulta { get; set; } = string.Empty;
    public string? Observaciones { get; set; }
    public string? Dni { get; set; }
}

public class LisReservaResponseDto
{
    public int Id { get; set; }
    public int IdPaciente { get; set; }
    public string? EstadoReserva { get; set; }
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime? FechaReserva { get; set; }

    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime? FechaAtencion { get; set; }

    [JsonConverter(typeof(CustomTimeSpanConverter))]
    public TimeSpan? HoraAtencion { get; set; }
    public string? MotivoConsulta { get; set; }
    public string? Observaciones { get; set; }
    public string? Dni { get; set; }
}

