using Microsoft.AspNetCore.Mvc;
using HAsystem.Dents.Domain.Common;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure.Core;
using HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.ListReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.GetReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.DeleteReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;

namespace HAsystem.Dents.Api.Endpoints;

public static class ReservaEndpoint
{
    public static RouteGroupBuilder MapReservaEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/Reserva");
        api.MapGet("/ListaReserva", ListReservaEndpointAsync);
        api.MapGet("/ObtenerReserva", GetReservaEndpointAsync);
        api.MapPost("/GrabarReserva", CreateReservaEndpointAsync);
        api.MapDelete("/DeleteReserva", DeleteReservaEndpointAsync);
        api.MapPut("/UpdateReserva", UpdateReservaEndpointAsync);

        return api;
    }

    private static async Task<IResult> ListReservaEndpointAsync([FromServices] ListReservaHandler listReservaHandler)
    {
        var result = await listReservaHandler.Handle();
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<LisReservaResponseDto>
            {
                Status = true,
                Lista = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> GetReservaEndpointAsync(GetReservaHandler listReservaHandler, [AsParameters] ReservaRequestDto request)
    {
        var result = await listReservaHandler.Handle(request);
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<ReservaResponseDto>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> CreateReservaEndpointAsync(CreateReservaHandler createReservaHandler, [FromBody] ReservaCreateRequestDto request)
    {
        var resultReserva = await createReservaHandler.Handle(request);
        return resultReserva.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<ReservaCreateResponseDTO>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> UpdateReservaEndpointAsync(UpdateReservaHandler updateReservaHandler, [FromBody] ReservaUpdateRequestDto request)
    {
        var resultReserva = await updateReservaHandler.Handle(request);
        return resultReserva.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<ReservaUpdateResponseDTO>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> DeleteReservaEndpointAsync(DeleteReservaHandler deleteReservaHandler, [FromBody] ReservaDeleteRequestDto request)
    {
        var resultReserva = await deleteReservaHandler.Handle(request);
        return resultReserva.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<ReservaDeleteResponseDTO>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
}
