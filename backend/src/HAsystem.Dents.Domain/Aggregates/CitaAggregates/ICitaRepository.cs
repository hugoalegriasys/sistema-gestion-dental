using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.CitaAggregates;

public interface ICitaRepository : IRepository<Cita>
{
    Task<Cita?> GetByIdAsync(int id);
    Task<bool> ExistsByReservaIdAsync(int idReserva);
    void Save(Cita cita);
    void Update(Cita cita);
}
