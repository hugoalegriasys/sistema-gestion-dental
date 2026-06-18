using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;
public static class CreatePacienteMapping
{
    public static Paciente MapToPaciente(this PacienteCreateRequestDto request)
    {
        return Paciente.Create(request.Nombre, request.Apellido, 
            request.FechaNacimiento, request.TelefonoFijo, request.Direccion, request.Dni, 
            request.Email, request.LugarNacimiento, request.Ciudad, 
            request.Celular, request.GradoInstruccion, request.Ocupacion, request.Procedencia, 
            request.AlergiaMedicamentos, request.Apoderado, request.TelefonoApoderado, request.Edad);
    }
    public static PacienteCreateResponseDTO MapToPacienteResponse(this Paciente paciente)
    {
        return new PacienteCreateResponseDTO(paciente.Dni, "Paciente registrado correctamente");
    }
}
