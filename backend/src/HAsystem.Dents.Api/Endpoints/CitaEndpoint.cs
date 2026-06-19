using HAsystem.Dents.Application.Features.CitaFeatures;
using HAsystem.Dents.Application.Features.CitaFeatures.ListCita;
using HAsystem.Dents.Application.Features.CitaFeatures.UpdateCita;
using HAsystem.Dents.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace HAsystem.Dents.Api.Endpoints;

public static class CitaEndpoint
{
    public static RouteGroupBuilder MapCitaEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/Cita");
        api.MapGet("/ListaCita", ListCitaEndpointAsync);
        api.MapPut("/UpdateCita", UpdateCitaEndpointAsync);

        return api;
    }

    private static async Task<IResult> ListCitaEndpointAsync([FromServices] ListCitaHandler handler)
    {
        var result = await handler.Handle();
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<CitaResponseDto>
            {
                Status = true,
                Lista = data
            }),
            onFailure: (apiException) => throw apiException);
    }

    private static async Task<IResult> UpdateCitaEndpointAsync(
        [FromServices] UpdateCitaHandler handler,
        [FromBody] UpdateCitaRequestDto request)
    {
        var result = await handler.Handle(request);
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<string>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
}
