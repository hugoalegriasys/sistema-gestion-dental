using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;
using HAsystem.Dents.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HAsystem.Dents.Infrastructure.Persistence.Repositories;

public class OdontogramaRepository : IOdontogramaRepository
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public OdontogramaRepository(DentalContext context)
    {
        _context = context;
    }

    public async Task<List<Odontograma>> ListByPacienteIdAsync(int idPaciente)
    {
        return await _context.Set<Odontograma>()
            .AsNoTracking()
            .Where(o => o.IdPaciente == idPaciente)
            .ToListAsync();
    }

    public async Task<Odontograma?> GetByPacienteAndDienteAsync(int idPaciente, int numeroDiente)
    {
        return await _context.Set<Odontograma>()
            .Where(o => o.IdPaciente == idPaciente && o.NumeroDiente == numeroDiente)
            .FirstOrDefaultAsync();
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
