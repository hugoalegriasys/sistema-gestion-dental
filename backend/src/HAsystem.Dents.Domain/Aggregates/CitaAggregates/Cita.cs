using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.CitaAggregates;

public class Cita : Entity<int>, IAggregateRoot
{
    public int IdReserva { get; private set; }
    public int IdPaciente { get; private set; }
    public DateTime FechaAtencion { get; private set; }
    public TimeSpan HoraAtencion { get; private set; }
    public string EstadoCita { get; private set; }
    public string? Diagnostico { get; private set; }
    public string? TratamientoRealizado { get; private set; }
    public string? Observaciones { get; private set; }
    public DateTime FechaRegistro { get; private set; }
    public Paciente Paciente { get; set; }
    public Reserva Reserva { get; set; }

    public Cita() { }

    private Cita(int idReserva, int idPaciente, DateTime fechaAtencion, TimeSpan horaAtencion, string estadoCita)
    {
        IdReserva = idReserva;
        IdPaciente = idPaciente;
        FechaAtencion = fechaAtencion;
        HoraAtencion = horaAtencion;
        EstadoCita = estadoCita;
        FechaRegistro = DateTime.Now;
    }

    public static Cita Create(int idReserva, int idPaciente, DateTime fechaAtencion, TimeSpan horaAtencion, string estadoCita)
    {
        return new(idReserva, idPaciente, fechaAtencion, horaAtencion, estadoCita);
    }

    public void Update(string estadoCita, string? diagnostico, string? tratamientoRealizado, string? observaciones)
    {
        EstadoCita = estadoCita;
        Diagnostico = diagnostico;
        TratamientoRealizado = tratamientoRealizado;
        Observaciones = observaciones;
    }
}
