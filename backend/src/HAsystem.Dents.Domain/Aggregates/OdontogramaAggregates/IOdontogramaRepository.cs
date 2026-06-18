using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;

public interface IOdontogramaRepository : IRepository<Odontograma>
{
    Task<List<Odontograma>> ListByPacienteIdAsync(int idPaciente);
    Task<Odontograma?> GetByPacienteAndDienteAsync(int idPaciente, int numeroDiente);
    void Save(Odontograma odontograma);
    void Update(Odontograma odontograma);
}
