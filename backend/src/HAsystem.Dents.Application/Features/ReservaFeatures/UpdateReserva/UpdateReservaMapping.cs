using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;
public static class UpdateReservaMapping
{
    public static void MapToUpdateReserva(this Reserva reserva, ReservaUpdateRequestDto request)
    {
        reserva.Update(
            request.IdPaciente,
            request.EstadoReserva,
            request.FechaReserva,
            request.FechaAtencion,
            request.HoraAtencion,
            request.MotivoConsulta,
            request.Dni,
            request.Observaciones
        );
    }
    public static ReservaUpdateResponseDTO MapToUpdateReservaResponse(this Reserva reserva)
    {
        return new ReservaUpdateResponseDTO(reserva.EstadoReserva, "Se actualizo correctamente");
    }
}
