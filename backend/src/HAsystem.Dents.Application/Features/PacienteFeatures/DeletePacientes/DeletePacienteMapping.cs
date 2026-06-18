using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAsystem.Dents.Application.Features.PacienteFeatures.UpdatePacientes;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.DeletePacientes;

    public static class DeletePacienteMapping
    {
        public static void MapToDeletePaciente(this Paciente paciente, PacienteDeleteRequestDto request)
    {
        paciente.ReplaceActivo(request.Activo);
    }
    public static PacienteDeleteResponseDTO MapToDeletePacienteResponse(this Paciente paciente)
        {
            return new PacienteDeleteResponseDTO(paciente.Dni, "Se desactivo correctamente");
        }
    }

