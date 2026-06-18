using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.Features.ReservaFeacture.ListReserva;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;

using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.GetReserva;

public class GetReservaHandler
{
    private readonly IValidator<ReservaRequestDto> _validator;
    private readonly IReservaRepository _reservaRepository;
    private readonly IReservaReadService _reservaService;


    public GetReservaHandler(IValidator<ReservaRequestDto> validator, IReservaRepository reservaRepository, IReservaReadService reservaService)
    {
        _validator = validator;
        _reservaRepository = reservaRepository;
        _reservaService = reservaService;
    }
    public async Task<Result<ReservaResponseDto>> Handle(ReservaRequestDto request)
    {
        //validación de aplicación
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(codeItem => new CustomError(string.Empty, codeItem.ErrorMessage, "Validacion"));

            return Result<ReservaResponseDto>.Failure(null, validationErrors);
        }

        var response = await _reservaService.GetReservaDtoAsync(request.dni);

        return Result<ReservaResponseDto>.Success(response.MapToReservaItem());

    }
}
