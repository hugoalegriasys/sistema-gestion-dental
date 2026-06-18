using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace HAsystem.Dents.Core;

public class ManejoExcepcionesMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ManejoExcepcionesMiddleware> _logger;

    public ManejoExcepcionesMiddleware(RequestDelegate next, ILogger<ManejoExcepcionesMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inesperado");

            var response = new
            {
                Status= false,
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                Category = "Error del Sistema"
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
