using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.HistorialClinicoAggregates;

public interface IHistorialClinicoRepository : IRepository<HistorialClinico>
{
    void Save(HistorialClinico historialClinico);
    void Update(HistorialClinico historialClinico);
}
