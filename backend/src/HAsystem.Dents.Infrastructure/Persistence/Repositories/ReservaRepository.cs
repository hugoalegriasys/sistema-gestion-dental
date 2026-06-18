using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;
using HAsystem.Dents.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HAsystem.Dents.Infrastructure.Persistence.Repositories;
public class ReservaRepository : IReservaRepository, IReservaReadService
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public ReservaRepository(DentalContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<LisReservaResponseDto>> ListReservaDtoAsync()
    {
        var query = _context.Reserva
                        .AsNoTracking()
                        .AsQueryable();

        return await query.Select(reserva => new LisReservaResponseDto(
             reserva.IdPaciente,
             reserva.EstadoReserva,
             reserva.FechaReserva.ToString(),
             reserva.FechaAtencion.ToString(),
             reserva.HoraAtencion.ToString(),
             reserva.MotivoConsulta,
             reserva.Observaciones,
             reserva.Dni
                )).ToListAsync();

    }

    public async Task<Reserva?> GetReservaDtoAsync(string dni)
    {

        return await _context.Reserva
            .AsNoTracking()
            .Where(p => p.Dni == dni)
            .FirstOrDefaultAsync();

    }

    public async Task<Reserva?> GetIdReservaDtoAsync(int id)
    {
        return await _context.Reserva
            .AsNoTracking()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<ReservaResponseDto>> CreateReservaDtoAsync(string dni)
    {
        var query = _context.Reserva
                        .AsNoTracking()
                        .AsQueryable();
        query = query.Where(c => c.Dni.Equals(dni));

        return await query.Select(reserva => new ReservaResponseDto(
       reserva.IdPaciente,
            reserva.EstadoReserva,
            reserva.FechaReserva.ToString(),
            reserva.FechaAtencion.ToString(),
            reserva.HoraAtencion.ToString(),
            reserva.MotivoConsulta,
            reserva.Observaciones,
            reserva.Dni)
                ).ToListAsync();

    }
    public void SaveReserva(Reserva reserva)
    {
        var reg = reserva.FechaReserva;
        _context.Reserva.Add(reserva);
    }
    public void UpdateReserva(Reserva reserva)
    {
        _context.Reserva.Update(reserva);

    }
}
