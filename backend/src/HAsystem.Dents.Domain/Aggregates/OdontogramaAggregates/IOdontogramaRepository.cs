using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;

public interface IOdontogramaRepository : IRepository<Odontograma>
{
    void Save(Odontograma odontograma);
    void Update(Odontograma odontograma);
}
