using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;

using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.ListReserva;

public class ListReservaHandler
{
    private readonly IReservaReadService _reservaService;
    public ListReservaHandler(IReservaReadService reservaService)
    {
        _reservaService = reservaService;
    }
    public async Task<Result<IEnumerable<LisReservaResponseDto>>> Handle()
    {
        //validación de aplicación


        var response = await _reservaService.ListReservaDtoAsync();

        return Result<IEnumerable<LisReservaResponseDto>>.Success(response);

    }
}
