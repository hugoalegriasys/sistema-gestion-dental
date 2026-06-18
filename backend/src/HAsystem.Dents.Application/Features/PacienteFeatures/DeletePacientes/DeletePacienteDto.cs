using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.DeletePacientes
{
    public record PacienteDeleteRequestDto(
     int Id,
     bool Activo
      );
    public record PacienteDeleteResponseDTO(string dni, string mensaje);
}
