using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.HistorialClinicoAggregates;

public class HistorialClinico : Entity<int>, IAggregateRoot
{
    public int IdPaciente { get; private set; }
    public DateTime FechaRegistro { get; private set; }
    public string Descripcion { get; private set; }
    public string? Observaciones { get; private set; }
    public Paciente Paciente { get; set; }

    public HistorialClinico() { }

    private HistorialClinico(int idPaciente, string descripcion, string? observaciones)
    {
        IdPaciente = idPaciente;
        FechaRegistro = DateTime.Today;
        Descripcion = descripcion;
        Observaciones = observaciones;
    }

    public static HistorialClinico Create(int idPaciente, string descripcion, string? observaciones = null)
    {
        return new(idPaciente, descripcion, observaciones);
    }

    public void Update(string descripcion, string? observaciones = null)
    {
        Descripcion = descripcion;
        Observaciones = observaciones;
    }
}
