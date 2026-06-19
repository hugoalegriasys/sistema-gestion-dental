using HAsystem.Dents.Application.Features.CitaFeatures;
using HAsystem.Dents.Domain.Aggregates.CitaAggregates;
using HAsystem.Dents.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HAsystem.Dents.Infrastructure.Persistence.Repositories;

public class CitaRepository : ICitaRepository, ICitaReadService
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public CitaRepository(DentalContext context)
    {
        _context = context;
    }

    public async Task<Cita?> GetByIdAsync(int id)
    {
        return await _context.Set<Cita>()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> ExistsByReservaIdAsync(int idReserva)
    {
        return await _context.Set<Cita>()
            .AnyAsync(c => c.IdReserva == idReserva);
    }

    public async Task<List<CitaResponseDto>> ListaCita()
    {
        var query = from cita in _context.Set<Cita>().AsNoTracking()
                    join paciente in _context.Paciente.AsNoTracking()
                    on cita.IdPaciente equals paciente.Id
                    select new CitaResponseDto(
                        cita.Id,
                        cita.IdReserva,
                        cita.IdPaciente,
                        paciente.Nombre,
                        paciente.Apellido,
                        paciente.Dni,
                        cita.FechaAtencion,
                        cita.HoraAtencion,
                        cita.EstadoCita,
                        cita.Diagnostico,
                        cita.TratamientoRealizado,
                        cita.Observaciones,
                        cita.FechaRegistro
                    );

        return await query.ToListAsync();
    }

    public void Save(Cita cita)
    {
        _context.Set<Cita>().Add(cita);
    }

    public void Update(Cita cita)
    {
        _context.Set<Cita>().Update(cita);
    }
}
