using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.DeleteReserva
{
    public record ReservaDeleteRequestDto(
     int Id,
     bool Activo
      );
    public record ReservaDeleteResponseDTO(string dni, string mensaje);
}
