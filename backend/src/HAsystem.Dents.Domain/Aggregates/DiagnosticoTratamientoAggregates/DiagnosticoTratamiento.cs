using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.DiagnosticoTratamientoAggregates;

public class DiagnosticoTratamiento : Entity<int>, IAggregateRoot
{
    public int IdPaciente { get; private set; }
    public DateTime Fecha { get; private set; }
    public string Diagnostico { get; private set; }
    public string? Tratamiento { get; private set; }
    public string? Observaciones { get; private set; }
    public Paciente Paciente { get; set; }

    public DiagnosticoTratamiento() { }

    private DiagnosticoTratamiento(int idPaciente, string diagnostico, string? tratamiento, string? observaciones)
    {
        IdPaciente = idPaciente;
        Fecha = DateTime.Today;
        Diagnostico = diagnostico;
        Tratamiento = tratamiento;
        Observaciones = observaciones;
    }

    public static DiagnosticoTratamiento Create(int idPaciente, string diagnostico, string? tratamiento = null, string? observaciones = null)
    {
        return new(idPaciente, diagnostico, tratamiento, observaciones);
    }

    public void Update(string diagnostico, string? tratamiento = null, string? observaciones = null)
    {
        Diagnostico = diagnostico;
        Tratamiento = tratamiento;
        Observaciones = observaciones;
    }
}
