using HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;
using HAsystem.Dents.Application.Features.PacienteFeatures.UpdatePacientes;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.GetPacientes;

public static class GetPacienteMapping
{
    public static PacienteResponseDto MapToPacienteItem(this Paciente paciente)
    {
        return new PacienteResponseDto(paciente.Id, 
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
            paciente.Edad);
    }
}
