namespace Ngsystem.Infrastructure.Dtos;

public class SaveReservaRequestDto
{
    public int IdPaciente { get; set; }
    public string EstadoReserva { get; set; } = string.Empty;
    public string FechaReserva { get; set; } = string.Empty;
    public string FechaAtencion { get; set; } = string.Empty;
    public string HoraAtencion { get; set; } = string.Empty;
    public string MotivoConsulta { get; set; } = string.Empty;
    public string? Observaciones { get; set; }
    public string? Dni { get; set; }
}

public class LisReservaResponseDto
{
    public int IdReserva { get; set; }
    public int IdPaciente { get; set; }
    public string? EstadoReserva { get; set; }
    public DateTime FechaReserva { get; set; }
    public DateTime FechaAtencion { get; set; }
    public string? HoraAtencion { get; set; }
    public string? MotivoConsulta { get; set; }
    public string? Observaciones { get; set; }
    public string? Dni { get; set; }
}

