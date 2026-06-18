using HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.GetReserva;

public static class GetReservaMapping
{
    public static ReservaResponseDto MapToReservaItem(this Reserva reserva)
    {
        return new ReservaResponseDto(
            reserva.IdPaciente,
            reserva.EstadoReserva,
            reserva.FechaReserva.ToString(),
            reserva.FechaAtencion.ToString(),
            reserva.HoraAtencion.ToString(),
            reserva.MotivoConsulta,
            reserva.Observaciones,
            reserva.Dni
           );
    }
}
