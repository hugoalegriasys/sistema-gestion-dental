using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.Features.ReservaFeacture.DeleteReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.DeleteReserva
{
    public class DeleteReservaHandler
    {
        private readonly IValidator<ReservaDeleteRequestDto> _validator;
        private readonly IReservaRepository _reservaRepository;
        private readonly IReservaReadService _reservaReadService;
        public DeleteReservaHandler(IValidator<ReservaDeleteRequestDto> validator, IReservaRepository reservaRepository, IReservaReadService reservaReadService)
        {
            _validator = validator;
            _reservaRepository = reservaRepository;
            _reservaReadService = reservaReadService;
        }

        public async Task<Result<ReservaDeleteResponseDTO>> Handle(ReservaDeleteRequestDto request)
        {
            // Validación asíncrona
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.Errors
                    .Select(err => new CustomError(string.Empty, err.ErrorMessage, "Validación")).ToList();
                return Result<ReservaDeleteResponseDTO>.Failure(null, validationErrors);
            }

            // Buscar paciente
            var reserva = await _reservaReadService.GetIdReservaDtoAsync(request.Id);
            if (reserva == null)
            {
                return Result<ReservaDeleteResponseDTO>.Failure(new CustomError("Reserva", "No encontrado", "Negocio"), null);
            }
            // Actualizar propiedades
            reserva.MapToDeleteReserva(request);
            // Guardar cambios
            _reservaRepository.UpdateReserva(reserva);
            await _reservaRepository.UnitOfWork.SaveAsync();
            // Mapear y responder
            var response = reserva.MapToDeleteReservaResponse();
            return Result<ReservaDeleteResponseDTO>.Success(response);
        }
    }
}
