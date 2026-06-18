using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.QueryServices;

public interface IPacienteReadService
{
    Task<IEnumerable<LisPacienteResponseDto>> ListPacienteDtoAsync();
    Task<Paciente> GetPacienteDtoAsync(string dni);
    Task<Paciente> GetIdPacienteDtoAsync(int id);
}
