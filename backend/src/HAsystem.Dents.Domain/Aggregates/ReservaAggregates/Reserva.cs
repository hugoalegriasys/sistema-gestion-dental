using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

public class Reserva : Entity<int>, IAggregateRoot
{
    public int IdPaciente { get; private set; }
    public string EstadoReserva { get; private set; }
    public DateTime FechaReserva { get; private set; }
    public DateTime FechaAtencion { get; private set; }
    public TimeSpan HoraAtencion { get; private set; }
    public string MotivoConsulta { get; private set; }
    public string? Observaciones { get; private set; }
    public string? Dni { get; private set; }
    public Paciente Paciente { get; set; }
    public Reserva() { }

    private Reserva(int idPaciente, string estadoReserva, DateTime fechaReserva,
                    DateTime fechaAtencion, TimeSpan horaAtencion, string dni, string motivoConsulta,
                    string? observaciones = null)
    {
        IdPaciente = idPaciente;
        EstadoReserva = estadoReserva;
        FechaReserva = fechaReserva;
        FechaAtencion = fechaAtencion;
        HoraAtencion = horaAtencion;
        Dni = dni;
        MotivoConsulta = motivoConsulta;
        Observaciones = observaciones;
    }

    public static Reserva Create(int idPaciente, string estadoReserva, DateTime fechaReserva,
            DateTime fechaAtencion, TimeSpan horaAtencion, string dni, string motivoConsulta,
            string? observaciones = null)
    {
        return new(idPaciente, estadoReserva, fechaReserva, fechaAtencion,
                              horaAtencion, dni, motivoConsulta, observaciones);
    }

    public void Update(int idPaciente, string estadoReserva, DateTime fechaReserva,
            DateTime fechaAtencion, TimeSpan horaAtencion, string motivoConsulta, string dni,
            string? observaciones = null)
    {
        IdPaciente = idPaciente;
        EstadoReserva = estadoReserva;
        FechaReserva = fechaReserva;
        FechaAtencion = fechaAtencion;
        HoraAtencion = horaAtencion;
        MotivoConsulta = motivoConsulta;
        Observaciones = observaciones;
        Dni = dni;
    }
}
