using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;

public class Odontograma : Entity<int>, IAggregateRoot
{
    public int IdPaciente { get; private set; }
    public DateTime Fecha { get; private set; }
    public int NumeroDiente { get; private set; }
    public string EstadoDiente { get; private set; }
    public string? Observaciones { get; private set; }
    public Paciente Paciente { get; set; }

    public Odontograma() { }

    private Odontograma(int idPaciente, int numeroDiente, string estadoDiente, string? observaciones)
    {
        IdPaciente = idPaciente;
        Fecha = DateTime.Today;
        NumeroDiente = numeroDiente;
        EstadoDiente = estadoDiente;
        Observaciones = observaciones;
    }

    public static Odontograma Create(int idPaciente, int numeroDiente, string estadoDiente, string? observaciones = null)
    {
        return new(idPaciente, numeroDiente, estadoDiente, observaciones);
    }

    public void Update(int numeroDiente, string estadoDiente, string? observaciones = null)
    {
        NumeroDiente = numeroDiente;
        EstadoDiente = estadoDiente;
        Observaciones = observaciones;
    }
}
