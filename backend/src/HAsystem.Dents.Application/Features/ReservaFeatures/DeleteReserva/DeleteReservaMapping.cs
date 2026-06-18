using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.DeleteReserva
{
    public static class DeleteReservaMapping
    {
        public static void MapToDeleteReserva(this Reserva reserva, ReservaDeleteRequestDto request)
        {
            //reserva.ReplaceActivo(request.Activo);
        }
        public static ReservaDeleteResponseDTO MapToDeleteReservaResponse(this Reserva reserva)
        {
            return new ReservaDeleteResponseDTO(reserva.Dni, "Se desactivo correctamente");
        }
    }
}
