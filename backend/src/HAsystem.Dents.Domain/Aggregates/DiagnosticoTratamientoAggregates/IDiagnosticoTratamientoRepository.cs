using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.DiagnosticoTratamientoAggregates;

public interface IDiagnosticoTratamientoRepository : IRepository<DiagnosticoTratamiento>
{
    void Save(DiagnosticoTratamiento diagnosticoTratamiento);
    void Update(DiagnosticoTratamiento diagnosticoTratamiento);
}
