using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Infrastructure.Persistence.Repositories;

public class OdontogramaRepository : IOdontogramaRepository
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public OdontogramaRepository(DentalContext context)
    {
        _context = context;
    }

    public void Save(Odontograma odontograma)
    {
        _context.Set<Odontograma>().Add(odontograma);
    }

    public void Update(Odontograma odontograma)
    {
        _context.Set<Odontograma>().Update(odontograma);
    }
}
