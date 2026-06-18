using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngsystem.Infrastructure.Dtos;
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

public class ItemReservaResponseDto
{
    public int IdPaciente { get; set; }
    public string? EstadoReserva { get; set; }
    public DateTime FechaReserva { get; set; }
    public DateTime FechaAtencion { get; set; }
    public string? HoraAtencion { get; set; }
    public string? MotivoConsulta { get; set; }
    public string? Observaciones { get; set; }
    public string? Dni { get; set; }
}

