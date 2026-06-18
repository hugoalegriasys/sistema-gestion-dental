using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;

public class UpdateReservaHandler
{
    private readonly IValidator<ReservaUpdateRequestDto> _validator;
    private readonly IReservaRepository _reservaRepository;
    private readonly IReservaReadService _reservaReadService;
    public UpdateReservaHandler(IValidator<ReservaUpdateRequestDto> validator, IReservaRepository reservaRepository, IReservaReadService reservaReadService)
    {
        _validator = validator;
        _reservaRepository = reservaRepository;
        _reservaReadService = reservaReadService;
    }

    public async Task<Result<ReservaUpdateResponseDTO>> Handle(ReservaUpdateRequestDto request)
    {
        // Validación asíncrona
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors
                .Select(err => new CustomError(string.Empty, err.ErrorMessage, "Validación")).ToList();
            return Result<ReservaUpdateResponseDTO>.Failure(null, validationErrors);
        }

        // Buscar paciente
        var reserva = await _reservaReadService.GetReservaDtoAsync(request.Dni);
        if (reserva == null)
        {
            return Result<ReservaUpdateResponseDTO>.Failure(new CustomError("Reserva", "No encontrado", "Negocio"), null);
        }
        // Actualizar propiedades
        reserva.MapToUpdateReserva(request);
        // Guardar cambios
        _reservaRepository.UpdateReserva(reserva);
        await _reservaRepository.UnitOfWork.SaveAsync();
        // Mapear y responder
        var response = reserva.MapToUpdateReservaResponse();
        return Result<ReservaUpdateResponseDTO>.Success(response);
    }

    public async Task Handle(ReservaRequestDto request)
    {
        throw new NotImplementedException();
    }
}