
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;
using HAsystem.Dents.Domain.Common;

namespace HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

public class Paciente :Entity<int>, IAggregateRoot
{
    public string ?Nombre { get;private set; }
    public string ?Apellido { get;private set; }
    public DateTime FechaNacimiento { get; private set; }
    public string ?TelefonoFijo { get;private set; }
    public string ?Direccion { get;private set; }
    public string? Dni { get; private set; }
    public string? Email { get; private set; }
    public DateTime FechaRegistro { get; private set; }
    public string? LugarNacimiento { get; private set; }
    public string? Ciudad { get; private set; }
    public string? Celular { get; private set; }
    public string? GradoInstruccion { get; private set; }
    public string? Ocupacion { get; private set; }
    public string? Procedencia { get; private set; }
    public string? AlegiaMedicamentos { get; private set; }
    public string? Apoderado { get; private set; }
    public string? TelefonoApoderado { get; private set; }
    public int? Edad { get; private set; }
    public bool? Activo { get; private set; }
    public Paciente() { }

    public ICollection<Reserva> Reservas { get; set; }
    // Constructor privado para garantizar uso de métodos de fábrica
    private Paciente(string nombre, string apellido, string fechaNacimiento, 
                     string telefono, string direccion, string dni, string? email
                     , string? lugarNacimiento, string? ciudad,
                     string? celular, string? gradoInstruccion, string? ocupacion, 
                     string? procedencia, string? alegiaMedicamentos, string? apoderado, 
                     string? telefonoApoderado, int? edad)
    {
        Nombre = nombre; 
        Apellido = apellido; 
        FechaNacimiento = DateTime.Parse(fechaNacimiento); 
        TelefonoFijo = telefono; 
        Direccion = direccion; Dni = dni;
        Email = email; 
        FechaRegistro = DateTime.Today; 
        LugarNacimiento = lugarNacimiento; 
        Ciudad = ciudad; Celular = celular;
        GradoInstruccion = gradoInstruccion; 
        Ocupacion = ocupacion; 
        Procedencia = procedencia; 
        AlegiaMedicamentos = alegiaMedicamentos;
        Apoderado = apoderado; 
        TelefonoApoderado = telefonoApoderado;
        Edad = edad;
        Activo = true; 
    }
    public void ReplaceActivo(bool activo)
    { 
        Activo=activo;
    }
    // Método de fábrica para crear una instancia
    public static Paciente Create(string nombre, string apellido, string fechaNacimiento, 
        string telefono, string direccion, string dni, string? email = null,
        string? lugarNacimiento = null, string? ciudad = null, string? 
        celular = null, string? gradoInstruccion = null, string? ocupacion = null, string? 
        procedencia = null, string? alegiaMedicamentos = null, string? apoderado = null, string? 
        telefonoApoderado = null, int? edad = null)
    {
        return new (nombre, apellido, fechaNacimiento, telefono, direccion, dni, email
            , lugarNacimiento, ciudad, celular, gradoInstruccion, ocupacion, 
            procedencia, alegiaMedicamentos, apoderado, telefonoApoderado, edad);
    }
  
    // Método de actualización desde el DTO
    public void Update(string nombre, string apellido, string fechaNacimiento, string telefono, 
        string direccion, string dni, string? email = null, string? 
        lugarNacimiento = null, string? ciudad = null, string? celular = null, string? gradoInstruccion = null, string? 
        ocupacion = null, string? procedencia = null, string? alegiaMedicamentos = null, string? 
        apoderado = null, string? telefonoApoderado = null, int? edad = null)
    {
        Nombre = nombre; 
        Apellido = apellido; 
        FechaNacimiento = DateTime.Parse(fechaNacimiento); 
        TelefonoFijo = telefono; 
        Direccion = direccion; 
        Dni = dni;
        Email = email; 
        FechaRegistro = DateTime.Today; 
        LugarNacimiento = lugarNacimiento; 
        Ciudad = ciudad; 
        Celular = celular;
        GradoInstruccion = gradoInstruccion;
        Ocupacion = ocupacion; 
        Procedencia = procedencia; 
        AlegiaMedicamentos = alegiaMedicamentos;
        Apoderado = apoderado; 
        TelefonoApoderado = telefonoApoderado;
        Edad = edad;
    }

    //public void ReplaceActivo(object activo)
    //{
    //    throw new NotImplementedException();
    //}
}