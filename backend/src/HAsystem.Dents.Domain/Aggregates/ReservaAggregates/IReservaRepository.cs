using HAsystem.Dents.Domain.Common;
namespace HAsystem.Dents.Domain.Aggregates.ReservaAggregates;
public interface IReservaRepository : IRepository<Reserva>
{
    void SaveReserva(Reserva reserva);
    void UpdateReserva(Reserva reserva);
}
