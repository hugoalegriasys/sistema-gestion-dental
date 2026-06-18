using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;
public static class CreateReservaMapping
{
    public static Reserva MapToReserva(this ReservaCreateRequestDto request)
    {
        return Reserva.Create(
            request.IdPaciente,
            request.EstadoReserva,
            request.FechaReserva,
            request.FechaAtencion,
            request.HoraAtencion,
            request.MotivoConsulta,
            request.Observaciones,
            request.Dni
            );
    }
    public static ReservaCreateResponseDTO MapToReservaResponse(this Reserva reserva)
    {
        return new ReservaCreateResponseDTO(reserva.Dni, "Reserva registrado correctamente");
    }
}
