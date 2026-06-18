
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;
using HAsystem.Dents.Domain.Common;
using System.Data;

namespace HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

public class Reserva : Entity<int>, IAggregateRoot
{
    
    public int IdPaciente { get; private set; }
    public string EstadoReserva { get; private set; }
    public DateTime FechaReserva { get; private set; }
    public DateTime FechaAtencion { get; private set; }
    public DateTime HoraAtencion { get; private set; }
    public string MotivoConsulta { get; private set; }
    public string? Observaciones { get; private set; }
    public string? Dni { get; private set; }
    public Paciente Paciente { get; set; }
    public Reserva() { }
    // Constructor privado para garantizar uso de métodos de fábrica
    private Reserva(int idPaciente, string estadoReserva, string fechaReserva,
                        string fechaAtencion, string horaAtencion, string dni, string motivoConsulta,
                        string? observaciones = null)
    {
        IdPaciente = idPaciente;
        EstadoReserva = estadoReserva;
        FechaReserva = DateTime.Parse(fechaReserva);
        FechaAtencion = DateTime.Parse(fechaAtencion);
        HoraAtencion = DateTime.Parse(horaAtencion);
        Dni = dni;
        MotivoConsulta = motivoConsulta;
        Observaciones = observaciones;

    }

    //public void ReplaceActivo(bool activo)
    //{ 
    //    Activo=activo;
    //}
    // Método de fábrica para crear una instancia
    public static Reserva Create(int idPaciente, string estadoReserva, string fechaReserva,
            string fechaAtencion, string horaAtencion, string dni, string motivoConsulta,
            string? observaciones = null)
    {
        return new(idPaciente, estadoReserva, fechaReserva, fechaAtencion,
                              horaAtencion, motivoConsulta, observaciones, dni);
    }

    // Método de actualización desde el DTO
    public void Update(int idPaciente, string estadoReserva, string fechaReserva,
            string fechaAtencion, string horaAtencion, string motivoConsulta, string dni,
            string? observaciones = null)
    {
        IdPaciente = idPaciente;
        EstadoReserva = estadoReserva;
        FechaReserva = DateTime.Parse(fechaReserva);
        FechaAtencion = DateTime.Parse(fechaAtencion);
        HoraAtencion = DateTime.Parse(horaAtencion);
        MotivoConsulta = motivoConsulta;
        Observaciones = observaciones;
        Dni = dni;
    }

    //public void ReplaceActivo(object activo)
    //{
    //    throw new NotImplementedException();
    //}
}