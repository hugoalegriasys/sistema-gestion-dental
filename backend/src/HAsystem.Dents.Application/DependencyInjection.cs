using FluentValidation;
using HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;
using HAsystem.Dents.Application.Features.PacienteFeatures.DeletePacientes;
using HAsystem.Dents.Application.Features.PacienteFeatures.GetPacientes;
using HAsystem.Dents.Application.Features.PacienteFeatures.ListPacientes;
using HAsystem.Dents.Application.Features.PacienteFeatures.UpdatePacientes;
using HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.DeleteReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.GetReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.ListReserva;
using HAsystem.Dents.Application.Features.ReservaFeacture.UpdateReserva;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace HAsystem.Dents.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetPacienteHandler>();
        services.AddScoped<ListPacienteHandler>();
        services.AddScoped<CreatePacienteHandler>();
        services.AddScoped<UpdatePacienteHandler>();
        services.AddScoped<DeletePacienteHandler>();

        services.AddScoped<GetReservaHandler>();
        services.AddScoped<ListReservaHandler>();
        services.AddScoped<CreateReservaHandler>();
        services.AddScoped<UpdateReservaHandler>();
        services.AddScoped<DeleteReservaHandler>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}