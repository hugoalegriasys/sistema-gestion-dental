using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;
public record ReservaCreateRequestDto(
    int IdPaciente,
    string EstadoReserva,
    string FechaReserva,
    string FechaAtencion,
    string HoraAtencion,
    string MotivoConsulta,
    string? Observaciones,
    string? Dni
    );

public record ReservaCreateResponseDTO(string dni, string mensaje);