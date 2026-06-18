using HAsystem.Dents.Domain.Aggregates.HistorialClinicoAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Infrastructure.Persistence.Repositories;

public class HistorialClinicoRepository : IHistorialClinicoRepository
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public HistorialClinicoRepository(DentalContext context)
    {
        _context = context;
    }

    public void Save(HistorialClinico historialClinico)
    {
        _context.Set<HistorialClinico>().Add(historialClinico);
    }

    public void Update(HistorialClinico historialClinico)
    {
        _context.Set<HistorialClinico>().Update(historialClinico);
    }
}
