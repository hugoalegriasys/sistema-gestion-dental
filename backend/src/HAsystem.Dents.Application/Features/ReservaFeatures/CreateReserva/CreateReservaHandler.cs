using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;

public class CreateReservaHandler
{
    private readonly IValidator<ReservaCreateRequestDto> _validator;
    private readonly IReservaRepository _reservaRepository;
    public CreateReservaHandler(IValidator<ReservaCreateRequestDto> validator, IReservaRepository reservaRepository)
    {
        _validator = validator;
        _reservaRepository = reservaRepository;
    }
    public async Task<Result<ReservaCreateResponseDTO>> Handle(ReservaCreateRequestDto request)
    {
        //validación de aplicación
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(codeItem => new CustomError(string.Empty, codeItem.ErrorMessage, "Validacion")).ToList();
            return Result<ReservaCreateResponseDTO>.Failure(null, validationErrors);
        }

        var reserva = request.MapToReserva();
        _reservaRepository.SaveReserva(reserva);
        await _reservaRepository.UnitOfWork.SaveAsync();
        var response = reserva.MapToReservaResponse();
        return Result<ReservaCreateResponseDTO>.Success(response);
    }
}
