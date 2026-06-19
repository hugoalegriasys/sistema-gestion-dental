using HAsystem.Dents.Api.Endpoints;
using HAsystem.Dents.Application;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;
using HAsystem.Dents.Infrastructure;
using HAsystem.Dents.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
//builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
//

// Usar el middleware de excepciones


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseMiddleware<ManejoExcepcionesMiddleware>();

app.MapPacienteEndpoint();
app.MapReservaEndpoint();
app.MapOdontogramaEndpoint();
app.MapCitaEndpoint();
app.Run();
