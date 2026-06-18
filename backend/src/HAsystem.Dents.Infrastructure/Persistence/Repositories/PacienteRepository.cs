using Microsoft.EntityFrameworkCore;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Infrastructure.Persistence.Repositories;
public class PacienteRepository : IPacienteRepository, IPacienteReadService
{
    private readonly DentalContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public PacienteRepository(DentalContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<LisPacienteResponseDto>> ListPacienteDtoAsync() 
    {
        var query = _context.Paciente
                        .AsNoTracking()
                        .AsQueryable()
                        .Where(p => p.Activo == true);

       return  await query.Select(paciente => new LisPacienteResponseDto(
    paciente.Id,
    paciente.Nombre,
    paciente.Apellido,
    paciente.FechaNacimiento.ToString(),
    paciente.TelefonoFijo,
    paciente.Direccion,
    paciente.Dni,
    paciente.Email,
    paciente.FechaRegistro.ToString(),
    paciente.LugarNacimiento,
    paciente.Ciudad,
    paciente.Celular,
    paciente.GradoInstruccion,
    paciente.Ocupacion,
    paciente.Procedencia,
    paciente.AlegiaMedicamentos,
    paciente.Apoderado,
    paciente.TelefonoApoderado,
    paciente.Edad)
               ).ToListAsync();
         
    }
    
    public async Task<Paciente?> GetPacienteDtoAsync(string dni)
    {
        
        return await _context.Paciente
            .AsNoTracking()
            .Where(p => p.Dni == dni)
            .FirstOrDefaultAsync();

    }

    public async Task<Paciente?> GetIdPacienteDtoAsync(int id)
    {
        return await _context.Paciente
            .AsNoTracking()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<PacienteResponseDto>> CreatePacienteDtoAsync(string dni)
    {
        var query = _context.Paciente
                        .AsNoTracking()
                        .AsQueryable();
        query = query.Where(c => c.Dni.Equals(dni));

        return await query.Select(paciente => new PacienteResponseDto(
    paciente.Id,
    paciente.Nombre,
    paciente.Apellido,
    paciente.FechaNacimiento.ToString(),
    paciente.TelefonoFijo,
    paciente.Direccion,
    paciente.Dni,
    paciente.Email,
    paciente.FechaRegistro.ToString(),
    paciente.LugarNacimiento,
    paciente.Ciudad,
    paciente.Celular,
    paciente.GradoInstruccion,
    paciente.Ocupacion,
    paciente.Procedencia,
    paciente.AlegiaMedicamentos,
    paciente.Apoderado,
    paciente.TelefonoApoderado,
    paciente.Edad)
                ).ToListAsync();

    }
    public void SavePaciente(Paciente paciente)
    {
        var reg = paciente.FechaRegistro;
        _context.Paciente.Add(paciente); 
    }
    public void UpdatePaciente(Paciente paciente)
    {
        _context.Paciente.Update(paciente);

    }
}

