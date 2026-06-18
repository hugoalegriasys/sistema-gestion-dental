using HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;
using HAsystem.Dents.Application.Features.PacienteFeatures.UpdatePacientes;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.Features.PacienteFeactures.UpdatePacientes;
public static class UpdatePacienteMapping
{
    public static void MapToUpdatePaciente(this Paciente paciente, PacienteUpdateRequestDto request)
    {
    paciente.Update(
    request.Nombre,
    request.Apellido,
    request.FechaNacimiento,
    request.TelefonoFijo,
    request.Direccion,
    request.Dni,
    request.Email,
    request.LugarNacimiento,
    request.Ciudad,
    request.Celular,
    request.GradoInstruccion,
    request.Ocupacion,
    request.Procedencia,
    request.AlergiaMedicamentos,
    request.Apoderado,
    request.TelefonoApoderado,
    request.Edad);
    }
    public static PacienteUpdateResponseDTO MapToUpdatePacienteResponse(this Paciente paciente)
    {
        return new PacienteUpdateResponseDTO(paciente.Dni, "Se actualizo correctamente");
    }
  
}