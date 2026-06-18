using HAsystem.Dents.Application.Features.OdontogramaFeatures.GetOdontogramaByPacienteId;
using HAsystem.Dents.Application.Features.OdontogramaFeatures.SaveOdontograma;
using HAsystem.Dents.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace HAsystem.Dents.Api.Endpoints;

public static class OdontogramaEndpoint
{
    public static RouteGroupBuilder MapOdontogramaEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/Odontograma");
        api.MapGet("/PorPaciente/{idPaciente:int}", GetOdontogramaByPacienteEndpointAsync);
        api.MapPost("/Guardar", SaveOdontogramaEndpointAsync);

        return api;
    }

    private static async Task<IResult> GetOdontogramaByPacienteEndpointAsync(
        [FromServices] GetOdontogramaByPacienteIdHandler handler,
        int idPaciente)
    {
        var result = await handler.Handle(idPaciente);
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<OdontogramaItemDto>
            {
                Status = true,
                Lista = data
            }),
            onFailure: (apiException) => throw apiException);
    }

    private static async Task<IResult> SaveOdontogramaEndpointAsync(
        [FromServices] SaveOdontogramaHandler handler,
        [FromBody] SaveOdontogramaRequestDto request)
    {
        var result = await handler.Handle(request);
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<SaveOdontogramaResponseDto>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
}
