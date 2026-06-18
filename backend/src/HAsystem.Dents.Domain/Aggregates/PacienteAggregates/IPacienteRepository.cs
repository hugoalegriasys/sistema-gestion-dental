using HAsystem.Dents.Domain.Common;
namespace HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
public interface IPacienteRepository: IRepository<Paciente>
{
    void SavePaciente(Paciente paciente);
    void UpdatePaciente(Paciente paciente);
}
