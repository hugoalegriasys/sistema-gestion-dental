using HAsystem.Dents.Domain.Aggregates.DiagnosticoTratamientoAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Infrastructure.Persistence.Repositories;

public class DiagnosticoTratamientoRepository : IDiagnosticoTratamientoRepository
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public DiagnosticoTratamientoRepository(DentalContext context)
    {
        _context = context;
    }

    public void Save(DiagnosticoTratamiento diagnosticoTratamiento)
    {
        _context.Set<DiagnosticoTratamiento>().Add(diagnosticoTratamiento);
    }

    public void Update(DiagnosticoTratamiento diagnosticoTratamiento)
    {
        _context.Set<DiagnosticoTratamiento>().Update(diagnosticoTratamiento);
    }
}
