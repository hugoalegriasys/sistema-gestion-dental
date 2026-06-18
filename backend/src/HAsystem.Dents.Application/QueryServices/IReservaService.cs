using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.QueryServices;

public interface IReservaReadService
{
    Task<IEnumerable<LisReservaResponseDto>> ListReservaDtoAsync();
    Task<Reserva> GetReservaDtoAsync(string dni);
    Task<Reserva> GetIdReservaDtoAsync(int id);
}
